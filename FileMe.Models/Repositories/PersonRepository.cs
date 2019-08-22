using NHibernate;

namespace FileMe.Models.Repositories
{
    public class PersonRepository : Repository<Person>
    {
        public PersonRepository(ISession session) : base(session) { }
    }
}
