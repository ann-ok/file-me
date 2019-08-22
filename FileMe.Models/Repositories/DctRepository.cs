using NHibernate;

namespace FileMe.Models.Repositories
{
    public class DctRepository: Repository<Dct>
    {
        public DctRepository(ISession session) : base(session) { }
    }
}
