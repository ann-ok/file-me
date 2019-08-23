using FileMe.DAL.Classes;
using FluentNHibernate.Mapping;

namespace FileMe.DAL.ClassesMap
{
    public class UserMap : ClassMap<User>
    {
        public UserMap()
        {
            Id(u => u.Id).GeneratedBy.HiLo("100");
            Map(u => u.FIO).Length(100);
            Map(u => u.Password).Length(500);
        }
    }
}
