using System;
using System.Collections.Generic;

namespace MyListHW
{
    class Program
    {
        static void Main(string[] args)
        {
            //MyList<int> mlist = new MyList<int>();
            //mlist.Add(55);
            //mlist.Add(66);
            //mlist.Add(55);
            //mlist.Add(66);
            //mlist.Add(55);
            //mlist.Add(66);
            //mlist.Add(55);
            //mlist.Add(66);



            MyList<int> list = new MyList<int>();

            list.Add(21);
            list.Add(94);
            list.Add(43);
            list.Add(61);



            Console.WriteLine(list.IndexOf(88));
            list.RemoveAt(8);

            for (int i = 0; i < list.Count; i++)
            {
                Console.Write($"{list[i]}\t");
            }
            Console.WriteLine();

        }
    }
}
