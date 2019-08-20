using System;

namespace FileMe.Models
{
    public class Folder
    {
        private int Id { get; set; }

        private string title;

        protected string Title
        {
            get { return title; }
            set
            {
                if (value == "") throw new Exception();
                title = value;
            }
        }

        protected DateTime creationDate;

        public Folder()
        {
            Id = GetId(Title);
        }

        public Folder(string title)
        {
            Title = title;
            creationDate = DateTime.Today;

            Id = GetId(Title);
        }

        //возможно будет использоваться функция для получения уникального кода по названию
        private int GetId(string title)
        {
            title = title.ToUpper();

            int code = 0; ;

            bool odd = true; //нечетная позиция
            int position = 1;

            foreach (char c in title)
            {
                if (odd)
                {
                    code += c * position;
                    odd = false;
                }
                else
                {
                    code -= (c - 600) * position; //id только положительное
                    odd = true;
                }
                position++;
            }

            return code * title.Length;
        }
    }
}
