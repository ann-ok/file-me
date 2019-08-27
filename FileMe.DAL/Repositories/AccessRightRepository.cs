using FileMe.DAL.Classes;
using FileMe.DAL.Filters;
using NHibernate;

namespace FileMe.DAL.Repositories
{
    public class AccessRightRepository : Repository<AccessRight, AccessRightFilter>
    {
        public AccessRightRepository(ISession session) : base(session) { }
    }
}
