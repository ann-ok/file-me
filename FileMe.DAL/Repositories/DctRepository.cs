using FileMe.DAL.Classes;
using NHibernate;

namespace FileMe.DAL.Repositories
{
    public class DctRepository: Repository<Dct>
    {
        public DctRepository(ISession session) : base(session) { }
    }
}
