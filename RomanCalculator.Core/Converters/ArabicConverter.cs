using System;
using System.Linq;
using RomanCalculator.Core.Data;

namespace RomanCalculator.Core.Converters
{
    public static class ArabicConverter
    {
        public const int MaximumNumeralValue = 3999;
        public const int MinimumNumeralValue = 1;
       
        public static string ToNumeral(int arabicNumber)
        {
            Guard.ThatIntegerIsInValidNumeralRange(arabicNumber);

            var numeralValues = Enum.GetValues(typeof(Numerals)).Cast<int>().ToList().OrderByDescending(x => x);
            var runningRoman = string.Empty;
            foreach (var numeralValue in numeralValues)
            {
                while (arabicNumber >= numeralValue && arabicNumber > 0)
                {
                    runningRoman += Enum.GetName(typeof(Numerals), numeralValue);
                    arabicNumber -= numeralValue;
                }
            }

            return runningRoman;
        }

        private static class Guard
        {
            public static void ThatIntegerIsInValidNumeralRange(int arabicNumber)
            {
                if(arabicNumber < MinimumNumeralValue || arabicNumber > MaximumNumeralValue)
                    throw new ArgumentOutOfRangeException(arabicNumber.ToString(), "Arabic value is outside expected range (1-3999)");
            }
        }
    }
}
