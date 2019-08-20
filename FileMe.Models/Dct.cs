using System.Collections.Generic;

namespace FileMe.Models
{
    public class Dct : Folder
    {
        private List<File> versions;

        private File curFile;

        public Dct(string path, Person author) 
        {
            versions.Add(new File(path, author));
            curFile = versions[versions.Count];

            Title = curFile.Title;
            creationDate = curFile.CreationDate;
        }
    }
}
