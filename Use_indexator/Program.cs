using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Use_indexator
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //Библиотека
            Console.WriteLine("Библиотека"); 
            Library lib = new Library("Central library", "Madison street 44", "+1234567891", "library21@gmail.com", new TimeSpan(7, 0, 0), new TimeSpan(19, 0, 0));
            Console.WriteLine(lib.ToString());
            lib.Add(new Book("Harry Potter", "J.K.Rowling", new DateTime(2001, 05, 12), 8651, 9999));
            lib.Add(new Book("Arduino Guide", "J.Blum", new DateTime(2011, 10, 21), 0132, 1000));
            Console.WriteLine(lib[0]);
            Console.WriteLine(lib[1]);
            Console.WriteLine();


            //Котоотель
            Console.WriteLine("Котоотель"); 
            Cathotel ch = new Cathotel("Горячие киски", "ул. Пушкина 10", Price_category.high, 9.2);
            //Owner ow1 = new Owner("Петрошенок Л.Д.", new DateTime(2001, 03, 11), "+79999999955", "Тяша");
            //Owner ow2 = new Owner("Петрошенок Л.Д.", new DateTime(2001, 03, 11), "+79999999955", "Кроша");
            //Owner ow3 = new Owner("Патка М.А.", new DateTime(1998, 12, 27), "+79999999933", "ДжиДжи");
            ch.AddOwner(new Owner("Патка М.А.", new DateTime(1998, 12, 27), "+79999999933", "ДжиДжи"));
            //ch.AddOwner(ow2);
            //ch.AddOwner(ow3);
            Console.WriteLine(ch.Clients[0]);
            Console.WriteLine(ch.ToString()); 
            Console.ReadKey();






        }
    }
}
