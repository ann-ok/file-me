using FileMe.DAL.Classes;
using FileMe.DAL.Filters;
using NHibernate;
using NHibernate.Criterion;
using System;
using System.Linq;

namespace FileMe.DAL.Repositories
{
    public class PersonRepository : Repository<Person, PersonFilter>
    {
        public PersonRepository(ISession session): base(session) { }

        protected override void SetupFilter(ICriteria crit, PersonFilter filter)
        {
            base.SetupFilter(crit, filter);

            if (filter.Group != null && filter.Group.Count > 0)
            {
                crit.Add(Restrictions.In("CreationAuthor", filter.Group.ToArray()));
            }
            if (!string.IsNullOrEmpty(filter.Login))
            {
                crit.Add(Restrictions.Eq("Login", filter.Login));
            }
            if (!string.IsNullOrEmpty(filter.FIO))
            {
                crit.Add(Restrictions.InsensitiveLike("FIO", filter.FIO, MatchMode.Anywhere));
            }
            if (!string.IsNullOrEmpty(filter.Email))
            {
                crit.Add(Restrictions.Eq("Email", filter.Email));
            }
            if (filter.CreationDate.From.HasValue)
            {
                crit.Add(Restrictions.Ge("CreationDate", filter.CreationDate.From.Value));
            }
            if (filter.CreationDate.To.HasValue)
            {
                crit.Add(Restrictions.Le("CreationDate", filter.CreationDate.To.Value));
            }
        }
    }
}
