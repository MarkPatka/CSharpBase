using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;


namespace Use_indexator
{
    internal class Library
    {
        private List<Book> books;
        const int maxBooksCount = 1000;

        #region Поля и свойства
        public string Name { get; set; }

        private string telephone="";
        public string Telephone
        {
            get => telephone;
            set
            {
                if (value.StartsWith("+") && value.Length <= 11)
                    telephone = value;
                else
                    throw new Exception("Incorrect format of telephone number!");
            }
        }


        private string email;
        public string Email
        {
            get => email;
            set
            {
                if (value.Contains(".com") || value.Contains(".ru") || value.Contains(".ya")) 
                    email = value;
                else
                    throw new Exception("Incorrect format of Email!");
            }
        }




        public string Adress { get; set; }


        private TimeSpan startWorkday;
        public TimeSpan StartWorkday
        {
            get => startWorkday;
            set
            {
                if (value <= TimeSpan.FromHours(8)) startWorkday = value;
                else
                    throw new ArgumentException("Bussines hours shouldn`t start later!");

            }
        }


        private TimeSpan endWorkday;
        public TimeSpan EndWorkday
        {
            get => endWorkday;
            set
            {
                if (value >= TimeSpan.FromHours(18)) endWorkday = value;
                else
                    throw new ArgumentException("Bussines hours shouldn`t end earlier!");

            }
        }


        public int BussinesHours => endWorkday.Hours - startWorkday.Hours;
        #endregion


        #region Конструкторы
        public Library() 
        { 
            books = new List<Book>();
        }

        public Library(string name, string adress, string telephone, string email)
            : this()
        { 
            Name = name; 
            Adress = adress;
            Telephone = telephone;
            Email = email;
        }

        public Library(string name, string adress, string telephone, string email, TimeSpan startwork, TimeSpan endwork) 
            : this(name, adress, telephone, email)
        {
            StartWorkday = startwork;
            EndWorkday = endwork;
        }
        #endregion
        #region Мeтоды
        public void Add(Book book)
        {
            if (books.Count < maxBooksCount) books.Add(book);
            else
                throw new Exception("All racks are full!");
        }

        public Book GetByIndex(int index)
        {
            if (index >= 0 && index <= maxBooksCount) return books[index];
                throw new Exception("Incorrect index");

        }

        public bool IsinStock(Book book)
        {
            for (int i = 0; i < books.Count; i++)
            {
                if (book.Title == books[i].Title) return true;
            }
            return false;
        }

        public void RentOut(Book book)
        {
            if (IsinStock(book) == true) books.Remove(book);
            else
                throw new ArgumentException("There`s not this book on the list!");
        }

        public Book this[int index]
        {
            get 
            {
                if (index >= 0 && index <= maxBooksCount - 1)
                    return books[index];
                throw new Exception("Incorrect index");
            }
            set 
            {
                if (index >= 0 && index <= maxBooksCount - 1)
                    books[index] = value;
                else
                    throw new Exception("Incorrect index");

            }
        }

        public override string ToString() => $"Название: {Name}\nАдрес: {Adress}\nТелефон: {Telephone}\nЭл.Почта: {Email}\nРабочий день с {StartWorkday}, до: {EndWorkday}";
        #endregion

    }
}
