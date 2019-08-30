using FileMe.DAL.Classes;
using FluentNHibernate.Mapping;

namespace FileMe.DAL.ClassesMap
{
    public class PersonMap : ClassMap<Person>
    {
        public PersonMap()
        {
            Id(p => p.Id).GeneratedBy.HiLo("100");
            References(u => u.Group, "GroupId");
            Map(p => p.FIO).Length(100);
            Map(p => p.UserName).Length(30);
            Map(p => p.Email);
            Map(p => p.Password).Length(100);
            Map(p => p.CreationDate);
            References(u => u.AvatarFile).Cascade.SaveUpdate();
        }
    }
}
