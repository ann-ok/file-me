using System;

namespace FileMe.DAL.Classes
{
    public class Folder
    {
        public virtual long Id { get; set; }

        [FastSearch]
        public virtual string Name { get; set; }

        public virtual Folder Parent { get; set; }

        public virtual DateTime CreationDate { get; set; }

        public virtual bool IsFile => false;

        //public virtual Person Author { get; set; }

        //public virtual IList<DctVersion> Versions { get; set; }
    }
}
