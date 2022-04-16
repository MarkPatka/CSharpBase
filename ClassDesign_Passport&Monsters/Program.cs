using System;

namespace ClassDesign
{
    class Program
    {
        static void Main(string[] args)
        {

            Passport p1 = new Passport(4012, 402544, "Отделом УФМС по г. СПб", new DateTime(1998, 03, 21), new DateTime(1991, 03, 21), Genders.Female, "CПб");
            Console.WriteLine(p1);

            IOHelper.Divider(100);

            Monster m1 = new Monster("Cody", TypesofMonster.fantom, 300, 150, 15, 71, "HSSSSAAA", "NOOOOOO");
            Console.WriteLine(m1.GetInfo);
        }
    }
}
