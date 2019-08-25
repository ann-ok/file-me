using Autofac;
using Autofac.Integration.Mvc;
using FileMe.App_Start;
using FileMe.Controllers;
using FileMe.DAL;
using FileMe.DAL.Repositories;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Microsoft.Owin;
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

            containerBuilder.RegisterControllers(Assembly.GetAssembly(typeof(HomeController)));
            containerBuilder.RegisterModule(new AutofacWebTypesModule());

            //регистрация репозиториев
            var types = typeof(RepositoryAttribute).Assembly.GetTypes();
            foreach (var type in types)
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

            var container = containerBuilder.Build();
            #endregion

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            app.UseAutofacMiddleware(container);
        }
    }
}