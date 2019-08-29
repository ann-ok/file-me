using System.Collections.Generic;
using System.ComponentModel;

namespace FileMe.DAL.Classes
{
    public class Group
    {
        public virtual long Id { get; protected set; }

        [FastSearch]
        public virtual string Name { get; set; }

        //виртуальная связь, которая будет создаваться NHibernate
        public virtual ISet<Person> People { get; protected set; }
    }
}
