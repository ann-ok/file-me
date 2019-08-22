using FluentNHibernate.Mapping;

namespace FileMe.Models
{
    public class Dct : Folder
    {
        public virtual string FilePath { get; set; }

        //public virtual string Type => FilePath.Substring(FilePath.LastIndexOf('.') + 1);
        public virtual string Type { get; set; }

        public virtual Person Author { get; set; }

        public class DctMap: SubclassMap<Dct>
        {
            public DctMap()
            {
                Map(u => u.FilePath).Length(500);
                Map(u => u.Type).Length(100);
                References(u => u.Author).Cascade.SaveUpdate();
            }
        }
    }
}
