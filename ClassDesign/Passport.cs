using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ClassDesign
{
    enum Genders { Male, Female, Other }

    class Passport
    {
        private int _serial;
        private int _number;
        private string _whomGiven;
        private DateTime _bddate;

        public DateTime DateGetPassport { get; set; }
        public string Name { get; set; }
        public Genders Gender { get; set; }
        public string City { get; set; }

        public int Serial
        {
            get { return _serial; }
            set
            {
                if (value >= 1000 && value <= 9999) _serial = value;
                else throw new Exception("Ошибка ввода серии паспорта");
            }
        }

        public int Number
        {
            get { return _number;  }
            set
            {
                if (value >= 100000 && value <= 999999) _number = value;
                else throw new Exception("Ошибка ввода номера паспорта");
            }
        }

        public string WhomGiven
        {
            get { return _whomGiven;  }
            set
            {
                if (!string.IsNullOrEmpty(value)) _whomGiven = value;
                else throw new Exception("Вы не ввели наименование органа выдавшего паспорт");
            }
        }

        public string GenderText
        {
            get
            {
                return (Gender == Genders.Male ? "мужской" : (Gender == Genders.Female ? "женский" : " "));
            }
        }
        
        public DateTime BDdate
        {
            set
            {
                if (value.AddYears(13) <= DateTime.Now && DateTime.Now.Year >= 1900) _bddate = value;
                else throw new Exception("Введена неверная дата рождения");
            }
            get { return _bddate; }
        }

        private int Age
        {
            get
            {
                return DateTime.Now.Year - BDdate.Year;
            }
        }

        public Passport() { }

        public Passport(int serial, int number, string whomGiven, DateTime bddate, DateTime get, Genders gender, string city)
        {
            Serial = serial;
            Number = number;
            WhomGiven = whomGiven;
            BDdate = bddate;
            DateGetPassport = get;
            Gender = gender;
            City = city;
        }

        private static bool IsActive(int Yearnow, int Yeargetpassport, int age)
        {
            if (age <= 20) return Yearnow - Yeargetpassport <= 7;
            if (age > 20 && age < 45) return Yearnow - Yeargetpassport < 25;
            else return Yearnow - Yeargetpassport < 55;
        }

        public string IsactiveText
        {
            get
            {
                if (IsActive(DateTime.Now.Year, DateGetPassport.Year, Age) == true) return "Паспорт действителен";
                else return "Паспорт не действителен";
            }
        }


        public override string ToString() 
        {
            return ($"Серия паспорта: {Serial}\nНомер: {Number}\nКем выдан: {WhomGiven}\nДата выдачи: {DateGetPassport.ToString("MMMM dd, yyyy")}\n" +
                $"Дата рождения: {BDdate.ToString("MMMM dd, yyyy")}\nПол: {GenderText}\nГород: {City}\n{IsactiveText} ");
        }
    }
}
