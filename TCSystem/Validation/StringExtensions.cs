using System;
using TC.Core.Utilities;

namespace TC.Core.Validation
{
    public static class StringExtensions
    {
        public static void IsValidInput(this string input)
        {
            if (!decimal.TryParse(input, out decimal result))
            {
                throw new ArgumentException(GlobalMessages.invalidInput);
            }
            else if (result <= 0)
            {
                throw new ArgumentException(GlobalMessages.invalidDecimal);
            }
        }
    }
}
