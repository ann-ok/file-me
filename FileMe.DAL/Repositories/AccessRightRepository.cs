using FileMe.DAL.Classes;
using NHibernate;

namespace FileMe.DAL.Repositories
{
    public class AccessRightRepository : Repository<AccessRight>
    {
        public AccessRightRepository(ISession session) : base(session) { }
    }
}
