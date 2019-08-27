using FileMe.DAL.Classes;
using FluentNHibernate.Mapping;

namespace FileMe.DAL.ClassesMap
{
    public class FolderMap : ClassMap<Folder>
    {
        public FolderMap()
        {
            Id(f => f.Id).GeneratedBy.HiLo("100");
            Map(f => f.Name).Length(100);
            Map(f => f.CreationDate);
            References(f => f.Parent).Cascade.SaveUpdate();
            //References(u => u.ParentFolder).Cascade.SaveUpdate();
            //HasMany(u => u.Versions).AsList().Inverse();
        }
    }
}
