using System;
using System.Collections.Generic;
using System.Linq;

namespace Hassium
{
    public static class Debug
    {
        public static void PrintTokens(List<Token> tokens)
        {
            var position = 0;
            foreach (Token token in tokens)
            {
                Console.WriteLine(position + new string(' ', tokens.Count.ToString().Length + 2 - position.ToString().Length) + "Type: " + token.TokenClass +
                                  new string(' ',
                                      tokens.Max(x => x.TokenClass.ToString().Length) + 3 -
                                      token.TokenClass.ToString().Length) + "Value: " + token.Value);
                position++;
            }
            Console.WriteLine("-- END OF TOKEN LIST --");
            Console.WriteLine();
        }
    }
}

