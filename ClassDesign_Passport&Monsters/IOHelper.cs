using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassDesign
{


    static class IOHelper
    {
        // Ввод 2-х точек 2D пространства с проверкой на числовой тип.
        public static (double, double) InputPoint(string msg)
        {
            Console.WriteLine(msg);
            double X;
            double Y;

            if (double.TryParse(Console.ReadLine(), out X));
            else
                throw new ArgumentException($"Введено не число!");

            if (double.TryParse(Console.ReadLine(), out Y));
            else
                throw new ArgumentException($"Введено не число!");


            return (X, Y);  
        }

        // Возвращает номер (string) элемента из списка, если последний был в нем найден
        // P.S. Я не уверен, что правильно понял суть метода, указанного в наименовании в вашем примере: * int TextMenu(string[] menu_items);
        public static int TextMenu(string[] menu_items)
        {
            Console.WriteLine("Номер какого элемента из списка желаете получить?");
            string find_item = Convert.ToString(Console.ReadLine());
            string s1 = find_item.ToLower();

            int position = -1;

            for (int i = 0; i < menu_items.Length; i++)
            {

                string s2 = menu_items[i].ToLower();

                if (s1 == s2) position = i;
            }

            if (position == -1) Console.WriteLine($"{find_item} не найден в списке!");

            Console.WriteLine(position + 1);
            return position + 1;
        }

        // Безопасный ввод с перегрузками на int и double
        public static int SaveInput(int min, int max, string message)
        {
            int num;
            do
            {
                Console.Write($"{message} [{min}-{max}]: ");
                num = Convert.ToInt32(Console.ReadLine());

            } while (num < min || num > max);
            return num;
        }
        public static double SaveInput(double min, double max, string message)
        {
            double num;
            do
            {
                Console.Write($"{message} [{min}-{max}]: ");
                num = Convert.ToDouble(Console.ReadLine());

            } while (num < min || num > max);
            return num;
        }


        // Вспомогательные методы класса, позволяющие вывести на консоль любой 1 или 2 объекта
        private static void ConsolePrint(object some1)
        {
            Console.Write($"{some1}");
        }

        private static void ConsolePrint(object some1, object some2)
        {
            Console.Write($"{some1} {some2}");
        }


        // Данный метод создает разделительную линию задаваемой длины, сепарируя блоки задач.
        public static void Divider(int len)
        {
            for (int i = 0; i < len; i++)
            {
                Console.Write("-");
            }
            Console.WriteLine();
        }


        // Создание массива из int в заданном диапазоне
        public static int[] GenerateArrayInt(int size, int min, int max)
        {
            int[] res = new int[size];
            Random rnd = new Random();
            for (int i = 0; i < res.Length; i++)
            {
                res[i] = rnd.Next(min, max + 1);
            }
            return res;
        }

        // Создание массива из double в заданном диапазоне
        public static double[] GenerateArrayDouble(int size, double min, double max)
        {
            double[] res = new double[size];
            Random rnd = new Random();
            for (int i = 0; i < res.Length; i++)
            {
                res[i] = rnd.NextDouble() * (max - min) + min;
            }
            return res;
        }

        // Преобразование массива в str
        public static string ArrayToStr(int[] arr)
        {
            string arr1 = string.Join(" ", arr);
            return arr1;
        }

        // Вывод на консоль 1 Dim. массива с перегрузками на  (int, double)
        public static void ArrConsOut1(int[] arr)
        {
            string str = string.Join(" ", arr);
            Console.WriteLine($"{str}");
        }
        public static void ArrConsOut1(double[] arr)
        {
            string str = string.Join(" ", arr);
            Console.WriteLine($"{str}");
        }


        // Создание матрицы из int
        public static int[,] GenerateMatrixInt(int rows, int cols)
        {
            Random rnd = new Random();
            int[,] matrix = new int[rows, cols];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = rnd.Next(10, 101);
                }
            }
            return matrix;
        }


        // Создание матрицы double
        public static double[,] GenerateMatrixDouble(int rows, int cols)
        {
            Random rnd = new Random();
            double[,] matrix = new double[rows, cols];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = rnd.Next(0, 1000);
                }
            }
            return matrix;
        }

        // Вывести матрицу на консоль с перегрузкой на int и double
        public static void PrintMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    ConsolePrint(matrix[i, j], "\t");
                }
                Console.WriteLine();
            }
        }
        public static void PrintMatrix(double[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    ConsolePrint(matrix[i, j], "\t");
                }
                Console.WriteLine();
            }
        }




    }
}
