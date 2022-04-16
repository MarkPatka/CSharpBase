using System;

namespace MyLinkedList
{
    public class Programm
    {
        static void Main(string[] args)
        {
            OneLinkedList<int> nodeList = new();
            

            nodeList.AddFirst(5);
            nodeList.AddFirst(3);
            nodeList.AddFirst(1);
            nodeList.AddFirst(7);
            nodeList.AddLast(12);
            nodeList.AddLast(8);

            nodeList.AddBefore(12, 4);

            nodeList.Invert();

            

            foreach (var data in nodeList)
            {
                Console.WriteLine($"{data}");
            }

            Console.WriteLine("---------------------------------------------------");


            List<int> list = nodeList.ToList();
            list.Sort();

            foreach (var data in list)
            {
                Console.WriteLine($"{data}");
            }




        }
    }
}
