using NHibernate;

namespace FileMe.Models.Repositories
{
    public class FolderRepository: Repository<Folder>
    {
        public FolderRepository(ISession session) : base(session) { }
    }
}
