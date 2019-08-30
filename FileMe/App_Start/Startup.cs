using Autofac;
using Autofac.Integration.Mvc;
using FileMe.App_Start;
using FileMe.Authorization;
using FileMe.Binders;
using FileMe.Controllers;
using FileMe.DAL;
using FileMe.Files;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using NHibernate;
using NHibernate.Dialect;
using NHibernate.Tool.hbm2ddl;
using Owin;
using System;
using System.Configuration;
using System.Reflection;
using System.Web.Mvc;
using System.Web.Routing;

[assembly: OwinStartup(typeof(Startup))]
namespace FileMe.App_Start
{
    public partial class Startup
    {
        public static void Configuration(IAppBuilder app)
        {
            //копируем из Global.asax
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            //подключение биндера
            ModelBinders.Binders.Add(typeof(BinaryFileWrapper), new BinaryFileModelBinder());

            //строка подключения
            var connectionString = ConfigurationManager.ConnectionStrings["MSSQL"];
            if (connectionString == null)
            {
                throw new Exception("Не найдена строка подключения");
            }

            #region Настройка контейнера
            //будет отвечать за связь объектов с БД
            var containerBuilder = new ContainerBuilder();

            //выполняется в момента первого запроса(Resolve) сессии
            containerBuilder.Register(x =>
            {
                var cfg = Fluently
                    //конфигурация для NHib
                    .Configure()
                        //параметры
                        .Database(MsSqlConfiguration.MsSql2012
                        .ConnectionString(connectionString.ConnectionString)
                        .Dialect<MsSql2012Dialect>())
                    //поиск всех маппингов из сборки в которой есть указанный класс
                    .Mappings(m => m.FluentMappings.AddFromAssemblyOf<RepositoryAttribute>())
                    .CurrentSessionContext("call");

                var conf = cfg.BuildConfiguration();

                //выводим данные в консоль и создаем таблицы, если их нет
                //new SchemaUpdate(conf).Execute(true, true);
                var schemeExport = new SchemaUpdate(conf);
                schemeExport.Execute(true, true);

                return cfg.BuildSessionFactory();
            }).As<ISessionFactory>().InstancePerRequest();

            containerBuilder
                .Register(x => x.Resolve<ISessionFactory>().OpenSession())
                .As<ISession>()
                .InstancePerRequest();

            containerBuilder.RegisterControllers(Assembly.GetAssembly(typeof(HomeController)))
                .PropertiesAutowired(); //чтобы работала инъекция через свойство
            containerBuilder.RegisterModule(new AutofacWebTypesModule());

            //регистрация репозиториев
            var typesR = typeof(RepositoryAttribute).Assembly.GetTypes();
            foreach (var type in typesR)
            {
                var repositoriesAttribute = type.GetCustomAttribute<RepositoryAttribute>(true);
                if (repositoriesAttribute == null)
                {
                    continue;
                }

                containerBuilder
                    .RegisterType(type)
                    .AsSelf()
                    .InstancePerRequest();
            }

            //регистрация провайдеров
            var typesFP = typeof(FileProviderAttribute).Assembly.GetTypes();
            foreach (var type in typesFP)
            {
                var fileProviderAttribute = type.GetCustomAttribute<FileProviderAttribute>(true);
                if (fileProviderAttribute == null)
                {
                    continue;
                }

                containerBuilder
                    .RegisterType(type)
                    .As<IFileProvider>();
            }

            var container = containerBuilder.Build();
            #endregion

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            app.UseAutofacMiddleware(container);

            #region Настройки для авторизации
            //на каждый owin контекст нужно создать новый UserManager
            app.CreatePerOwinContext(() =>
                new UserManager(new IdentityStore(DependencyResolver.Current.GetService<ISession>())));

            //так же на каждый контекст определяем SignInManager
            app.CreatePerOwinContext<SignInManager>((opt, context) =>
                new SignInManager(context.GetUserManager<UserManager>(), context.Authentication));

            //настройки аутенфикации
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login"),
                Provider = new CookieAuthenticationProvider()
            });
            #endregion
        }
    }
}