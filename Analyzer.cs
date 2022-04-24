using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathExpressionsAnalyzer
{
    internal class Analyzer
    {
        public string Path { get; set; }
        private int FileLength => File.ReadAllText(Path).Length;
        private char GetCharByIndex => File.ReadAllText(Path)[Index - 1];

        private int index;
        public int Index
        {
            get => index;
            set
            {
                if (value < 0 || value > FileLength) 
                    throw new ArgumentOutOfRangeException(nameof(value), $"- Invalid index.\nIndex range is: {FileLength}");
                index = value;
            }
        }

        public Analyzer(string path)
        {
            Path = path;
            index = 0;
        }
            

        public void Reset() => Index = 0;



        private bool EndOfFile => Index == FileLength + 1;

        //private Token GetEndToken()
        //{
        //    if(EndOfFile)
        //        return new Token(TokenType.End, "END OF FILE");
        //    else
        //        return new Token(TokenType.Error, "Illegal Token!");
        //}

        private Token GetAssignToken()
        {
            Index++;
            if (!EndOfFile && GetCharByIndex == '=')
                return new Token(TokenType.Assign, "=");
            else
                return new Token(TokenType.Error, "Illegal Token!");
        }
        private Token GetVariableToken()
        {
            Index++;
            if (!EndOfFile && IsVariable(GetCharByIndex))
                return new Token(TokenType.Variable, $"{GetCharByIndex}");
            else
                return new Token(TokenType.Error, "Illegal Token!");
        }

        private Token GetOperatorToken()
        {
            Index++;
            if (!EndOfFile && IsOperator(GetCharByIndex))
                return new Token(TokenType.Operator, $"{GetCharByIndex}");
            else
                return new Token(TokenType.Error, "Illegal Token!");
        }

        private Token GetIdentToken()
        {
            Index++;
            if (!EndOfFile && IsBlank(GetCharByIndex))
                return new Token(TokenType.Ident, $"{GetCharByIndex}");
            else
                return new Token(TokenType.Error, "Illegal Token!");
        }

        private Token GetDightToken()
        {
            Index++;
            if (!EndOfFile && IsDight(GetCharByIndex))
                return new Token(TokenType.Number, $"{GetCharByIndex}");
            else
                return new Token(TokenType.Error, "Illegal Token!");
        }
        
        private Token GetErrorToken(int index, string value)
        {
            Index++;
            return new Token(TokenType.Error, $"Error: {value}.\nPosition: {index - 1}, {GetCharByIndex}");
        }



        public Token GetToken()
        {

            using StreamReader sr = new StreamReader(Path);
            {
                char ch = File.ReadAllText(Path)[Index];
                while (Index < FileLength)
                {
                    //if (EndOfFile) return GetEndToken();
                    if (IsVariable(ch)) return GetVariableToken();
                    if (IsOperator(ch)) return GetOperatorToken();
                    if (IsDight(ch)) return GetDightToken();
                    if (IsBlank(ch)) return GetIdentToken();
                    if (ch == '=') return GetAssignToken();
                }
                return GetErrorToken(Index, "Illegal Token!");
            }
        }

        public List<Token> GetAllTokens()
        {
            List<Token> tokens = new List<Token>();
            for (int i = 0; i < FileLength; i++)
            {
                tokens.Add(GetToken());
                if (i == FileLength - 1) tokens.Add(new Token(TokenType.End, "END OF FILE"));

            }
            return tokens;
        }

        private bool IsVariable(char c) => (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z');
        private bool IsDight(char c) => (c >= '0' && c <= '9');
        private bool IsOperator(char c) => (c == '+' || c == '-' || c == '*' || c == '/' || c == '^');
        private bool IsBlank(char c) => (c == '\n' || c == '\t' || c == ' ' || c == '\r' || c == '\0');







    }
}
