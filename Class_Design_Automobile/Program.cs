using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class_Design_Automobile
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Vehicle v1 = new Vehicle(8000, 12345678, new DateTime(2015, 03, 12), Marks.BMW, BodyVersions.Sedan, Motors.Petrol);
            Console.WriteLine(v1.ToString());






        }
    }
}