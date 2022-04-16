using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;


namespace Use_indexator
{
    internal class Owner
    {
        public string FIO { get; set; }
        public string PetName { get; set; }

        public Cat Cat;


        private DateTime byear;
        public DateTime BYear
        {
            get => byear;
            set
            {
                if (value.Year >= 1940 && value.Year - 18 >= 0) byear = value;
                else
                    throw new ArgumentException("Проверьте дату рождения");
            }
        }


        private string telephone;
        public string Telephone
        {
            get => telephone;
            set
            {
                Regex tel_reg = new Regex(@"^+[1-9]{1}|[1-9]{2}\d{10}|\d{9}");
                if (tel_reg.IsMatch(value)) telephone = value;
                else
                    throw new ArgumentException("Телефон введен некорректно.\nПр. +79999999999");
            }
        }


        public Owner() { }

        public Owner(string fio, DateTime byear, string telephone, string petname)
            : this()
        {
            FIO = fio;
            BYear = byear;
            Telephone = telephone;
            Cat = new Cat(petname);
        }

        public override string ToString() => $"Name: {FIO}, BD: {BYear}, Telephone: {Telephone}, {Cat}";

    }
}
