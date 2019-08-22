using NHibernate;

namespace FileMe.Models.Repositories
{
    public class DctVersionRepository: Repository<DctVersion>
    {
        public DctVersionRepository(ISession session) : base(session) { }
    }
}
