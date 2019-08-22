using NHibernate;

namespace FileMe.Models.Repositories
{
    public class GroupRepository: Repository<Group>
    {
        public GroupRepository(ISession session): base(session) { }
    }
}
