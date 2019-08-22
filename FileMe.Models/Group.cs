using FluentNHibernate.Mapping;
using System.Collections.Generic;

namespace FileMe.Models
{
    public class Group
    {
        public virtual long Id { get; set; }

        public virtual string Title { get; set; }

        //виртуальная связь, которая будет создаваться NHibernate
        public virtual IList<Person> People { get; set; }
    }

    public class GroupMap: ClassMap<Group>
    {
        public GroupMap()
        {
            Id(u => u.Id); //.GeneratedBy.HiLo("100");
            Map(u => u.Title).Length(100);
            HasMany(u => u.People).AsList().Inverse().KeyColumn("Id");
        }
    }
}
