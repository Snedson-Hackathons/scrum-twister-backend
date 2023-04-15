using System;
using System.Text;

namespace Scrum_Twister.Core.Services
{
    public class HeximalNumbersGeneratorService
    {
        public string GenerateNextNumber(int digitCount)
        {
            var sb = new StringBuilder();
            var random = new Random();
            for (int i = 0; i < digitCount; i++)
            {
                var nextDecimalNumber = random.Next(0, 16);
                string heximalDigit = nextDecimalNumber.ToString("X").ToLower();

                sb.Append(heximalDigit);
            }

            return sb.ToString();
        }
    }
}
