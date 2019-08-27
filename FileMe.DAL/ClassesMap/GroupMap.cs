using FileMe.DAL.Classes;
using FluentNHibernate.Mapping;

namespace FileMe.DAL.ClassesMap
{
    public class GroupMap : ClassMap<Group>
    {
        public GroupMap()
        {
            Id(g => g.Id).GeneratedBy.HiLo("100");
            Map(g => g.Name).Length(100);
            //За сохранение связи между группой и пользователем отвечает группа.
            HasMany(g => g.People).KeyColumn("GroupId").Inverse().Cascade.AllDeleteOrphan();
        }
    }
}
