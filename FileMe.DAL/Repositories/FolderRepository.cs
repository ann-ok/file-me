using FileMe.DAL.Classes;
using FileMe.DAL.Filters;
using NHibernate;
using NHibernate.Criterion;

namespace FileMe.DAL.Repositories
{
    public class FolderRepository: Repository<Folder, FolderFilter>
    {
        public FolderRepository(ISession session) : base(session) { }

        protected override void SetupFilter(ICriteria crit, FolderFilter filter)
        {
            base.SetupFilter(crit, filter);

            if (filter.Parent != null)
            {
                crit.Add(Restrictions.Eq("Parent", filter.Parent));
            }
            else
            {
                crit.Add(Restrictions.IsNull("Parent"));
            }
        }
    }
}
