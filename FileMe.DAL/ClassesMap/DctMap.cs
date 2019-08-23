using FileMe.DAL.Classes;
using FluentNHibernate.Mapping;

namespace FileMe.DAL.ClassesMap
{
    public class DctMap : SubclassMap<Dct>
    {
        public DctMap()
        {
            Map(u => u.FilePath).Length(500);
            Map(u => u.Type).Length(100);
            References(u => u.Author).Cascade.SaveUpdate();
        }
    }
}
