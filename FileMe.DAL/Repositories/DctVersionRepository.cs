using FileMe.DAL.Classes;
using NHibernate;

namespace FileMe.DAL.Repositories
{
    class DctVersionRepository: Repository<DctVersion>
    {
        public DctVersionRepository(ISession session) : base(session) { }
    }
}
