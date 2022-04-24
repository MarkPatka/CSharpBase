using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathExpressionsAnalyzer
{
    public enum TokenType
    {
        Error,
        Number,
        Ident,
        Assign,
        Operator,
        Variable,
        End
    }

    public struct Token
    {

        public TokenType Type { get; set; }
        public string Value { get; set; }

        public Token(TokenType type, string value)
        {
            Type = type;
            Value = value;
        }

        public override string ToString() => $"Token: {Type}\nValue: {Value}";

    }
}
