using System;
namespace _10092020
{
    public class TokenGenerator
    {
        public TokenGenerator()
        {
        }

        public static string GenerateToken()
        {
            //For illustration purpose generating a unique guid always as token.
            return Guid.NewGuid().ToString();
        }
    }
}
