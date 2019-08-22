using FluentNHibernate.Mapping;
using System.Collections.Generic;

namespace FileMe.Models
{
    public class Person
    {
        public virtual int Id { get; set; }

        public virtual string Login { get; set; }

        public virtual string Password { get; set; }

        public virtual Group Group { get; set; }

        public virtual IList<Dct> Dcts { get; set; }
    }

    public class PersonMap: ClassMap<Person>
    {
        public PersonMap()
        {
            Id(u => u.Id).GeneratedBy.HiLo("100");
            Map(u => u.Login).Length(100);
            Map(u => u.Password).Length(100);
            References(u => u.Group).Cascade.SaveUpdate();
            HasMany(u => u.Dcts).AsList().Inverse();
        }
    }

}
