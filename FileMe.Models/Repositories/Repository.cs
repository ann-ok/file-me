using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileMe.Models.Repositories
{
    [Repositories]
    public class Repository<T>
        where T: class
    {
        protected ISession session;

        public Repository(ISession session)
        {
            this.session = session;
        }

        public virtual T Load(long id)
        {
            return session.Get<T>(id);
        }

        public virtual void Save(T entity)
        {
            session.Save(entity);
        }
    }
}
