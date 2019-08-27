using FileMe.DAL.Classes;
using FluentNHibernate.Mapping;

namespace FileMe.DAL.ClassesMap
{
    public class AccessRightMap : ClassMap<AccessRight>
    {
        public AccessRightMap()
        {
            Id(a => a.Id).GeneratedBy.HiLo("100");
            //HasOne(u => u.Folder).Constrained().Cascade.SaveUpdate();
            Map(a => a.AccessLevel);
            //HasOne(u => u.Group).Constrained().Cascade.SaveUpdate();
        }
    }
}
