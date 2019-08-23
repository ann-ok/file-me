using FileMe.DAL.Classes;
using FluentNHibernate.Mapping;

namespace FileMe.DAL.ClassesMap
{
    public class DctVersionMap : ClassMap<DctVersion>
    {
        public DctVersionMap()
        {
            Id(u => u.Id).GeneratedBy.HiLo("100");
            References(u => u.Document).Cascade.SaveUpdate();
        }
    }
}
