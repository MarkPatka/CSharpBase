using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Use_indexator
{
    internal class Book
    {
        #region Поля и свойства
        public string Title { get; set; }
        public string Author { get; set; }


        private int id;
        public int ID
        {
            get => id;
            set
            {
                if (value < 100 || value > 99999)
                    throw new ArgumentException("Incorrect ID number!");
                else
                    id = value;

            }
        }


        private int circulation;
        public int Circulation
        {
            get => circulation;
            set
            {
                if (value < 10 || value >= 9999999)
                    throw new ArgumentException("Incorrect number of copies!");
                circulation = value;
            }
        }

        public DateTime ReleaseDate { get; set; }
        #endregion

        #region Конструкторы
        public Book(string title, string author, DateTime releaseDate)
        {
            Title = title;
            Author = author;
            ReleaseDate = releaseDate;
        }

        public Book(string title, string author, DateTime releaseDate, int id, int circulation)
            : this(title, author, releaseDate)
        {
            ID = id;
            Circulation = circulation;
        }
        #endregion

        public override string ToString()
        {
            return $"Название: {Title}, Автор: {Author}, ID: {ID}, Тираж: {Circulation} экз., Дата печати: {ReleaseDate}.";
        }
    }
}
