using FileMe.DAL.Classes;
using FluentNHibernate.Mapping;

namespace FileMe.DAL.ClassesMap
{
    public class FolderMap : ClassMap<Folder>
    {
        public FolderMap()
        {
            Id(u => u.Id).GeneratedBy.HiLo("100");
            Map(u => u.Title).Length(100);
            Map(u => u.CreationDate);
            //References(u => u.ParentFolder).Cascade.SaveUpdate();
            //HasMany(u => u.Versions).AsList().Inverse();
        }
    }
}
