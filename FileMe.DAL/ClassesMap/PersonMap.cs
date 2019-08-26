﻿using FileMe.DAL.Classes;
using FluentNHibernate.Mapping;

namespace FileMe.DAL.ClassesMap
{
    public class PersonMap : ClassMap<Person>
    {
        public PersonMap()
        {
            Id(u => u.Id).GeneratedBy.HiLo("100");
            References(u => u.Group, "GroupId");
            Map(u => u.FIO).Length(100);
            Map(u => u.Login).Length(100);
            Map(u => u.Email).Length(100);
            Map(u => u.Password).Length(100);
        }
    }
}
