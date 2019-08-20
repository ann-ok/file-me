using System;
using System.IO;

namespace FileMe.Models
{
    public class File
    {
        private string authorName;

        private string type;

        private string filePath;

        private string FilePath
        {
            get { return filePath; }
            set
            {
                if (value == "") throw new Exception();
                filePath = value;
            }
        }

        public DateTime CreationDate { get; private set; }

        public string Title { get; private set; }

        public File(string path, Person author)
        {
            FilePath = path;

            //вынести в функцию
            //?зачем нам отдельно имя и расширение
            string fileName = Path.GetFileName(FilePath);
            int ind = fileName.LastIndexOf('.');

            Title = fileName.Substring(0, ind);
            type = fileName.Substring(ind + 1);

            authorName = author.GetLogin();
            CreationDate = DateTime.Today;
        }
    }
}
