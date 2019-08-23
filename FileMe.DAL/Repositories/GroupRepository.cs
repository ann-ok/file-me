using FileMe.DAL.Classes;
using NHibernate;

namespace FileMe.DAL.Repositories
{
    public class GroupRepository: Repository<Group>
    {
        public GroupRepository(ISession session) : base(session) { }
    }
}
