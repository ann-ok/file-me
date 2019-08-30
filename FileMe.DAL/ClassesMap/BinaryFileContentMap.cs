using FileMe.DAL.Classes;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileMe.DAL.ClassesMap
{
    public class BinaryFileContentMap : ClassMap<BinaryFileContent>
    {
        public BinaryFileContentMap()
        {
            Id(f => f.Id).GeneratedBy.HiLo("100");
            Map(f => f.Content).Length(int.MaxValue);
            References(f => f.BinaryFile).Cascade.SaveUpdate();
        }
    }
}
