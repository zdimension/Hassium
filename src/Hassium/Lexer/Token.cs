using System;

namespace Hassium
{
    public enum TokenType
    {
        Brace,
        Bracket,
        Identifier,
        String,
        Number,
        Parentheses,
        Comma,
        Operation,
        OpAssign,
        Comparison,
        Assignment,
        Exception,
        EndOfLine,
        UnaryOperation

    }
    public class Token
    {
        public TokenType TokenClass { get; private set; }
        public object Value { get; private set; }

        public Token(TokenType type, object value)
        {
            this.TokenClass = type;
            this.Value = value;
        }
    }
}

