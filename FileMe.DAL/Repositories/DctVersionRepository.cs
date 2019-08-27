using FileMe.DAL.Classes;
using FileMe.DAL.Filters;
using NHibernate;

namespace FileMe.DAL.Repositories
{
    class DctVersionRepository: Repository<DctVersion, DctVersionFilter>
    {
        public DctVersionRepository(ISession session) : base(session) { }
    }
}
