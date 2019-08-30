using FileMe.DAL.Classes;
using FileMe.DAL.Filters;
using NHibernate;

namespace FileMe.DAL.Repositories
{
    public class BinaryFileRepository : Repository<BinaryFile, BinatyFileFilter>
    {
        public BinaryFileRepository(ISession session) : base(session) { }
    }
}
