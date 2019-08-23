using FileMe.DAL.Classes;
using NHibernate;

namespace FileMe.DAL.Repositories
{
    public class FolderRepository: Repository<Folder>
    {
        public FolderRepository(ISession session) : base(session) { }
    }
}
