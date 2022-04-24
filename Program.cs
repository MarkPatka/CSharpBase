using MathExpressionsAnalyzer;
using System;

class Program
{
    static void Main(string[] args)
    {
        Console.BackgroundColor = ConsoleColor.Black;
        Console.ForegroundColor = ConsoleColor.Green;


        List<Token> Tokens = new List<Token>();
        Analyzer az = new(@"D:\Study\Workflow\С#\homeworks\MathExpressionsAnalyzer\Expressions\Math.txt");
        foreach (Token token in az.GetAllTokens())
        {
            Console.WriteLine(token);
        }



    }
}

