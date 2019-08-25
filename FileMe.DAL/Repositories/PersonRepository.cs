using FileMe.DAL.Classes;
using NHibernate;

namespace FileMe.DAL.Repositories
{
    public class PersonRepository : Repository<Person>
    {
        public PersonRepository(ISession session): base(session) { }
    }
}
