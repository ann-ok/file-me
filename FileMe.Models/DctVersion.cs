using FluentNHibernate.Mapping;

namespace FileMe.Models
{
    public class DctVersion
    {
        public virtual int Id { get; set; }

        public virtual Folder Document { get; set; }
    }

    public class DctVersionMap: ClassMap<DctVersion>
    {
        public DctVersionMap()
        {
            Id(u => u.Id).GeneratedBy.HiLo("100");
            References(u => u.Document).Cascade.SaveUpdate();
        }
    }
}
