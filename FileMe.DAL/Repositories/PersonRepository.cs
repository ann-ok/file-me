using FileMe.DAL.Classes;
using NHibernate;
using NHibernate.Criterion;
using System;

namespace FileMe.DAL.Repositories
{
    public class PersonRepository : Repository<Person>
    {
        public PersonRepository(ISession session): base(session) { }

        public bool Exists(string login)
        {
            var crit = session.CreateCriteria<Person>()
                .Add(Restrictions.Eq("Login", login))
                .SetProjection(Projections.Count("Id"));

            var count = Convert.ToInt64(crit.UniqueResult());

            return count > 0;
        }
    }
}
