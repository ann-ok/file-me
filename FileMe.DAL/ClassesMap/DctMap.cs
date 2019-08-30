using FileMe.DAL.Classes;
using FluentNHibernate.Mapping;

namespace FileMe.DAL.ClassesMap
{
    public class DctMap : SubclassMap<Dct>
    {
        public DctMap()
        {
            Map(d => d.Type).Length(100);
        }
    }
}
