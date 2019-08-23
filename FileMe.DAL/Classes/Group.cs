using System.Collections.Generic;

namespace FileMe.DAL.Classes
{
    public class Group
    {
        public virtual long Id { get; set; }

        public virtual string Title { get; set; }

        //виртуальная связь, которая будет создаваться NHibernate
        public virtual IList<Person> People { get; set; }
    }
}
