using FileMe.DAL.Classes;
using FluentNHibernate.Mapping;

namespace FileMe.DAL.ClassesMap
{
    public class BinaryFileMap: ClassMap<BinaryFile>
    {
        public BinaryFileMap()
        {
            Id(f => f.Id).GeneratedBy.HiLo("100");
            Map(f => f.Name).Length(255);
            Map(f => f.ContentType).Length(50);
            Map(f => f.Length);
        }
    }
}
