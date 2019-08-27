using FileMe.DAL.Classes;
using FluentNHibernate.Mapping;

namespace FileMe.DAL.ClassesMap
{
    public class DctVersionMap : ClassMap<DctVersion>
    {
        public DctVersionMap()
        {
            Id(d => d.Id).GeneratedBy.HiLo("100");
            References(d => d.Document).Cascade.SaveUpdate();
        }
    }
}
