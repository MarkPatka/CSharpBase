using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class_Design_Automobile
{
    internal class Vehicle
    {
        private int mileage;
        private DateTime manufactureDate;
        Marks mark;
        BodyVersions bodyVersion;
        Motors motor;


        public long VimCode { get; set; }
        public int Mileage
        {
            get => mileage;
            set
            {
                if (value < 0 || value > 1000000)
                    throw new ArgumentException("Значение выходит из диапазона допустимых значений");
                mileage = value;

            }
        }

        public int ManufactureYear => ManufactureDate.Year;


        public DateTime ManufactureDate
        {
            get => manufactureDate;
            set
            {
                if (value.Year >= 1990 && value <= DateTime.Now)
                    manufactureDate = value;
                else throw new ArgumentException("Вышел срок Эксплуатации");
            }
        }

        public int YearsInUse => DateTime.Now.Year - ManufactureDate.Year;

        public Marks Mark { get; set; }
        public BodyVersions BodyVersion { get; set; }
        public Motors Motor { get; set; }
        public string MarksText => EnumText.GetEnumElementText(mark);
        public string BodyVersionText => EnumText.GetEnumElementText(bodyVersion);
        public string MotorText => EnumText.GetEnumElementText(motor);

        public Vehicle() { }

        public Vehicle(int vimCode, DateTime manifactureYear, Marks mark, BodyVersions version, Motors motor)
            : this()
        {
            VimCode = vimCode;
            ManufactureDate = manifactureYear;
            Mark = mark;
            BodyVersion = version;
            Motor = motor;
        }

        public Vehicle(int mileage, int vimCode, DateTime manifactureYear, Marks mark, BodyVersions version, Motors motor)
            : this(vimCode, manifactureYear, mark, version, motor)
        {
            Mileage = mileage;
        }

        public override string ToString()
        {
            return $"Модель: {Mark}, Кузов: {BodyVersion}, Тип двигателя: {Motor}, Пробег: {Mileage}, Vim Code: {VimCode}, Лет в использовании: {YearsInUse}";
        }

    }
}
