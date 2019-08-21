using System;
using System.IO;

namespace FileMe.Models
{
    public class Dct : Folder
    {
        public string FilePath { get; set; }

        public string Type { get; private set; }

        public Person Author { get; set; }

        public Dct() { }

        public Dct(string filePath, Person author, DateTime creationDate) 
        {
            FilePath = filePath;
            SetTypeAndTitleFile(Path.GetFileName(FilePath));
            Author = author;
            CreationDate = creationDate;
            //? ParentFolder = 
        }

        private void SetTypeAndTitleFile(string fileName)
        {
            int ind = fileName.LastIndexOf('.');

            Title = fileName.Substring(0, ind);
            Type = fileName.Substring(ind + 1);
        }
    }
}
