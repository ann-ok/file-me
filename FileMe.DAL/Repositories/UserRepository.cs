using FileMe.DAL.Classes;
using NHibernate;

namespace FileMe.DAL.Repositories
{
    public class UserRepository : Repository<User>
    {
        public UserRepository(ISession session)
            : base(session)
        {
        }
    }
}
