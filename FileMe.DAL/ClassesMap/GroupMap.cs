using FileMe.DAL.Classes;
using FluentNHibernate.Mapping;

namespace FileMe.DAL.ClassesMap
{
    public class GroupMap : ClassMap<Group>
    {
        public GroupMap()
        {
            Id(u => u.Id).GeneratedBy.HiLo("100");
            Map(u => u.Title).Length(100);
            HasMany(u => u.People).AsList().Inverse().KeyColumn("Id");
        }
    }
}
