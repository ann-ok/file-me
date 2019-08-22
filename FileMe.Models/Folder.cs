using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;

namespace FileMe.Models
{
    public class Folder
    {
        public virtual int Id { get; set; }

        public virtual string Title { get; set; }

        public virtual DateTime CreationDate { get; set; }

        //public virtual Folder ParentFolder { get; set; }

        public virtual IList<DctVersion> Versions { get; set; }
    }

    public class FolderMap: ClassMap<Folder>
    {
        public FolderMap()
        {
            Id(u => u.Id).GeneratedBy.HiLo("100");
            Map(u => u.Title).Length(100);
            Map(u => u.CreationDate);
            //References(u => u.ParentFolder).Cascade.SaveUpdate();
            HasMany(u => u.Versions).AsList().Inverse();
        }
    }
}
