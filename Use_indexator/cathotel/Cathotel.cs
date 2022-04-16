using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;


namespace Use_indexator
{
    internal class Cathotel
    {
        private Dictionary<Owner, Cat> clients;

        private List<Owner> owners;
        private List<Cat> cats;

        private int[] id_s = new int[101];
        private void FillID()
        {
            for (int i = 1; i < id_s.Length; i++)
            {
                id_s[i] = i;
            }
        }


        private int MaxRoomCount = 100;

        #region Свойства
        public string Name { get; set; }

        private string address;
        public string Address
        {
            get => address;
            set
            {
                Regex address_reg = new Regex(@"((\b\w+?)\s|.\1\b)|((\b\w+?)-\b(w+?)\s|.\2\b)\1[1-9]{1}\d{1}|\d{2}|\s\.", RegexOptions.IgnoreCase);
                if (address_reg.IsMatch(value)) address = value;
                else
                    throw new ArgumentException("Формат адреса некорректен!\nПр.(улица Пушкина 10) или (пр-кт. Пушкина 10.");
            }
        }

        Price_category Category;

        private double rating;
        public double Rating
        {
            get => rating;
            set
            {
                if (value > 0 && value <= 10)
                    rating = value;
                else
                    throw new ArgumentException("Рейтинг отеля в диапазоне 0-10");
            }
        }
        #endregion


        public Cat this[Owner owner]
        {
            get
            {
                if (cats.Count != 0 && cats.Count >= owners.Count)
                    return clients[owner];
                throw new ArgumentException("Некорректный индекс");
            }   
            set
            {
                if (cats.Count != 0 && cats.Count >= owners.Count) clients[owner] = value;
                else
                    throw new ArgumentException("Некорректный индекс");
            }
        }

        #region Индексаторы для list owners и cats
        public Owner this[int index]
        {
            get
            {
                if (index > 0 && index <= 99)
                    return owners[index];
                throw new ArgumentException("Некорректный индекс");
            }
            set
            {
                if (index > 0 && index <= 99) owners[index] = value;
                else
                    throw new ArgumentException("Некорректный индекс");
            }
        }

        //public Cat this[string name]
        //{
        //    get
        //    {
        //        for (int i = 0; i < cats.Count; i++)
        //        {
        //            if (cats[i].Name.ToUpper() == name.ToUpper()) return cats[i];
        //        }
        //        throw new Exception("Питомца с таким именем нет!");

        //    }
        //    set
        //    {
        //        for (int i = 0; i < cats.Count; i++)
        //        {
        //            if (cats[i].Name.ToUpper() == name.ToUpper())
        //            {
        //                cats[i] = value;
        //                return;
        //            }
        //        }
        //        throw new Exception("Питомца с таким именем нет!");
        //    }
        //}
        #endregion


        public Cathotel() 
        { 
            clients = new Dictionary<Owner, Cat>();
            cats = new List<Cat>();
            owners = new List<Owner>();
        }

        public Cathotel(string name, string address, Price_category category, double rating)
            : this()
        {

            Name = name;
            Address = address;
            Category = category;
            Rating = rating;
            
        }

        public void AddOwner(Owner owner)
        {
            if (MaxRoomCount > 0)
            {
                clients.Add(owner, owner.Cat);
                owners.Add(owner);
                cats.Add(owner.Cat);
                MaxRoomCount--;
            }
            else
                throw new Exception("Свободных мест нет!");

        }


        public List<string> Clients
        {
            get => clients.Keys.Select(c => c.ToString()).ToList();

        }

        public override string ToString() => $"Отель {Name}, Адрес: {Address}\n" +
                                             $"Постояльцы\n-->  {String.Join("\n--> ", Clients)}";






    }
}
