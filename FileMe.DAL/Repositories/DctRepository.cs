using FileMe.DAL.Classes;
using FileMe.DAL.Filters;
using NHibernate;

namespace FileMe.DAL.Repositories
{
    public class DctRepository: Repository<Dct, DctFilter>
    {
        public DctRepository(ISession session) : base(session) { }
    }
}
