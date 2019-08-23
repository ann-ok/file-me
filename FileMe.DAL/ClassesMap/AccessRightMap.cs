using FileMe.DAL.Classes;
using FluentNHibernate.Mapping;

namespace FileMe.DAL.ClassesMap
{
    public class AccessRightMap : ClassMap<AccessRight>
    {
        public AccessRightMap()
        {
            Id(u => u.Id).GeneratedBy.HiLo("100");
            //HasOne(u => u.Folder).Constrained().Cascade.SaveUpdate();
            Map(u => u.AccessLevel);
            //HasOne(u => u.Group).Constrained().Cascade.SaveUpdate();
        }
    }
}
