using FluentNHibernate.Mapping;

namespace FileMe.Models
{
    public class Access
    {
        public virtual long Id { get; set; }

        public virtual Folder Folder { get; set; }

        public virtual AccessLevels AccessLevel { get; set; }

        public virtual Group Group { get; set; }
    }

    public enum AccessLevels
    {
        Reading,
        Writing,
        Full
    }

    public class AccessMap: ClassMap<Access>
    {
        public AccessMap()
        {
            Id(u => u.Id).GeneratedBy.HiLo("100");
            HasOne(u => u.Folder).Constrained().Cascade.SaveUpdate();
            Map(u => u.AccessLevel);
            HasOne(u => u.Group).Constrained().Cascade.SaveUpdate();
        }
    }
}
