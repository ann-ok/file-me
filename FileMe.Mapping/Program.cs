using Autofac;
using FileMe.Models;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Dialect;
using NHibernate.Tool.hbm2ddl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileMe.Mapping
{
    class Program
    {
        static void Main(string[] args)
        {
            const string CONNECTION_STRING = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Anna\Desktop\Курсы\file-me\FileMe.Mapping\Database1.mdf;Integrated Security=True";
           
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
                        .ConnectionString(CONNECTION_STRING)
                        .Dialect<MsSql2012Dialect>())
                    //поиск всех маппингов из сборки в которой есть указанный класс
                    .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Person>());

                var conf = cfg.BuildConfiguration();

                //выводим данные в консоль и создаем таблицы, если их нет
                //new SchemaUpdate(conf).Execute(true, true);
                var schemeExport = new SchemaUpdate(conf);
                schemeExport.Execute(true, true);

                return cfg.BuildSessionFactory();
            }).As<ISessionFactory>().SingleInstance();

            containerBuilder.Register(x => x.Resolve<ISessionFactory>().OpenSession())
                .As<ISession>();

            var container = containerBuilder.Build();
            #endregion

            var g = new Group { Id = 3, Title = "гру546" };
            Person person1 = new Person { Group = g, Login = "23t456", Password = "ert" };
<<<<<<< HEAD
=======
            //Person person2 = new Person { Group = g, Login = "25t", Password = "ert" };

            
>>>>>>> mapping

            var session = container.Resolve<ISession>();
            using (var tran = session.BeginTransaction())
            {
                try
                {
                    session.Save(person1);
                    tran.Commit();
                }
                catch (Exception e)
                {
                    Console.WriteLine("\n" + e.Message);
                    tran.Rollback();
                }
            }
        }
    }
}
