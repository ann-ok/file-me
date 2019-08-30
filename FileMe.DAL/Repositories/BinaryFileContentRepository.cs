using FileMe.DAL.Classes;
using FileMe.DAL.Filters;
using NHibernate;
using NHibernate.Criterion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileMe.DAL.Repositories
{
    public class BinaryFileContentRepository : Repository<BinaryFileContent, BinaryFileContentFilter>
    {
        public BinaryFileContentRepository(ISession session) : base(session) { }

        public BinaryFileContent GetByBinaryFile(BinaryFile file)
        {
            var crit = session.CreateCriteria<BinaryFileContent>()
                .Add(Restrictions.Eq("BinaryFile", file));
            return crit.UniqueResult<BinaryFileContent>();
        }
    }
}
