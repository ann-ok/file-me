﻿using NHibernate;
using NHibernate.Criterion;
using System;
using System.Collections.Generic;

namespace FileMe.DAL.Repositories
{
    [Repository]
    public class Repository<T>
            where T : class
    {
        protected ISession session;

        public Repository(ISession session)
        {
            this.session = session;
        }

        public virtual IList<T> GetAll() => session.CreateCriteria(typeof(T)).List<T>();

        public virtual T Load(long id)
        {
            return session.Get<T>(id);
        }

        public virtual void Save(T entity)
        {
            using (var tran = session.BeginTransaction())
            {
                try
                {
                    session.Save(entity);
                    tran.Commit();
                }
                catch(Exception e)
                {
                    Console.WriteLine("/n" + e.Message);
                    tran.Rollback();
                }
            }
        }
    }
}
