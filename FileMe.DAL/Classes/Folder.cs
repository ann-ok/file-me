using System;

namespace FileMe.DAL.Classes
{
    public class Folder
    {
        public virtual int Id { get; set; }

        public virtual string Title { get; set; }

        public virtual DateTime CreationDate { get; set; }

        //public virtual Folder ParentFolder { get; set; }

        //public virtual IList<DctVersion> Versions { get; set; }
    }
}
