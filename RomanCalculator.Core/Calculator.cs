using RomanCalculator.Core.Converters;

namespace RomanCalculator.Core
{
    public static class Calculator
    {
        public static string Add(string addend1, string addend2)
        {
            var numericAddend1 = NumeralConverter.ToArabic(addend1);
            var numericAddend2 = NumeralConverter.ToArabic(addend2);

            var sum = numericAddend1 + numericAddend2;
            return ArabicConverter.ToNumeral(sum);
        }
    }
}