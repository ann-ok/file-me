using FileMe.DAL.Classes;
using FileMe.DAL.Filters;
using NHibernate;
using NHibernate.Criterion;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace FileMe.DAL.Repositories
{
    [Repository]
    public class Repository<T, F> : IRepository
            where T: class
            where F: BaseFilter
    {
        protected ISession session;

        public Repository(ISession session)
        {
            this.session = session;
        }

        public virtual IList<T> GetAll() => session.CreateCriteria<T>().List<T>();

        public virtual T Load(long? id)
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
                    tran.Rollback();
                    throw new Exception(e.Message);
                }
            }
        }

        public virtual void Update(T entity)
        {
            using (var tran = session.BeginTransaction())
            {
                try
                {
                    session.Update(entity);
                    tran.Commit();
                }
                catch (Exception e)
                {
                    tran.Rollback();
                    throw new Exception(e.Message);
                }
            }
        }

        public virtual void Delete(T entity)
        {
            using (var tran = session.BeginTransaction())
            {
                try
                {
                    session.Delete(entity);
                    tran.Commit();
                }
                catch (Exception e)
                {
                    tran.Rollback();
                    throw new Exception(e.Message);
                }
            }
        }

        public bool Exists(string field, string fieldName)
        {
            var crit = session.CreateCriteria<T>()
                .Add(Restrictions.Eq(fieldName, field))
                .SetProjection(Projections.Count("Id"));

            var count = Convert.ToInt64(crit.UniqueResult());

            return count > 0;
        }

        public T Get(string field, string fieldName)
        {
            var crit = session.CreateCriteria<T>().Add(Restrictions.Eq(fieldName, field));
            var list = crit.List<T>();
            return list[0];

        }

        public virtual IList<T> Find(F filter, FetchOptoins fetchOptoins = null)
        {
            var crit = session.CreateCriteria<T>();

            if (filter != null)
            {
                SetupFilter(crit, filter);
            }

            if (fetchOptoins != null)
            {
                SetupFetchOptions(crit, fetchOptoins);
            }

            return crit.List<T>();
        }

        protected virtual void SetupFetchOptions(ICriteria crit, FetchOptoins fetchOptoins)
        {
            if (!string.IsNullOrEmpty(fetchOptoins.SortExpression))
            {
                crit.AddOrder(fetchOptoins.SortDirection == SortDirection.Asc ?
                    Order.Asc(fetchOptoins.SortExpression) :
                    Order.Desc(fetchOptoins.SortExpression));
            }

            if (fetchOptoins.First != null)
            {
                crit.SetFirstResult(fetchOptoins.First.Value);
            }

            if (fetchOptoins.Count != null)
            {
                crit.SetMaxResults(fetchOptoins.Count.Value);
            }
        }

        protected virtual void SetupFilter(ICriteria crit, F filter)
        {
            if (filter.Id.HasValue)
            {
                crit.Add(Restrictions.IdEq(filter.Id.Value));
            }
            if (!string.IsNullOrEmpty(filter.SearchString))
            {
                var properties = typeof(T).GetProperties();
                AbstractCriterion clause = null;

                foreach (var property in properties)
                {
                    //определяем участвует ли свойство в поиске
                    var fs = property.GetCustomAttribute<FastSearchAttribute>();
                    if (fs == null)
                    {
                        continue;
                    }

                    AbstractCriterion like;
                    
                    switch (fs.FiledType)
                    {
                        case FiledType.Int:
                            var proj = Projections
                                .Cast(NHibernateUtil.Int32, Projections.Property(property.Name));
                            like = Restrictions.InsensitiveLike(proj, filter.SearchString, MatchMode.Anywhere);
                            clause = (clause == null) ? like : Restrictions.Or(clause, like);
                            break;
                        case FiledType.ComplexEntity:
                            var c = crit.CreateCriteria(property.Name);
                            c.Add(Restrictions.InsensitiveLike("Name", filter.SearchString, MatchMode.Anywhere));
                            break;
                        default:
                            like = Restrictions.InsensitiveLike(property.Name, filter.SearchString, MatchMode.Anywhere);
                            clause = (clause == null) ? like : Restrictions.Or(clause, like);
                            break;
                    }
                }

                if (clause != null)
                {
                    crit.Add(clause);
                }
            }
        }
    }
}
