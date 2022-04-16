using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Config_xml_reader
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Game gm1 = new Game(Games.Witcher, Genres.RPG, "CDprojectRED", 9.8);
            //Console.WriteLine(gm1.ToString());

            Game gm2 = new Game(Games.Warhammer, Genres.RPG, "THQ", 9.1);
            Console.WriteLine(gm2.ToString());

            //Game gm3 = new Game(Games.Bioshock, Genres.Action, "Takes-Two", 8.4);
            //Console.WriteLine(gm3.ToString());


            Console.ReadKey();
        }
    }
}
