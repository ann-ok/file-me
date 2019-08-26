using FileMe.DAL.Classes;
using FluentNHibernate.Mapping;

namespace FileMe.DAL.ClassesMap
{
    public class GroupMap : ClassMap<Group>
    {
        public GroupMap()
        {
            Id(u => u.Id).GeneratedBy.HiLo("100");
            Map(u => u.Name).Length(100);
            //За сохранение связи между группой и пользователем отвечает группа.
            HasMany(u => u.People).KeyColumn("GroupId").Inverse().Cascade.AllDeleteOrphan();
        }
    }
}
