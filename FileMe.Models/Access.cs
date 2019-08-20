using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileMe.Models
{
    public class Access
    {
        private Folder folder;

        private AccessLevel accessLevel;

        private Groups group;

        public Access(Folder folder, AccessLevel accessLevel, Groups group)
        {
            this.folder = folder;
            this.accessLevel = accessLevel;
            this.group = group;
        }
    }

    public enum AccessLevel
    {
        Reading,
        Writing,
        Full
    }
}
