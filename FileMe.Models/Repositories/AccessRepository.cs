using NHibernate;

namespace FileMe.Models.Repositories
{
    public class AccessRepository: Repository<Access>
    {
        public AccessRepository(ISession session) : base(session) { }
    }
}
