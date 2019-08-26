using System.Collections.Generic;

namespace FileMe.DAL.Classes
{
    public class Group
    {
        public virtual long Id { get; protected set; }

        public virtual string Name { get; set; }

        //виртуальная связь, которая будет создаваться NHibernate
        public virtual ISet<Person> People { get; protected set; }
    }
}
