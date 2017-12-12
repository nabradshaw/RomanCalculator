using System;
using System.Collections;
using System.Linq;
using RomanCalculator.Core.Data;

namespace RomanCalculator.Core.Converters
{
    public static class NumeralConverter
    {
        public static int ToArabic(string romanNumeral)
        {
            Guard.AgainstIllegalNumeralRepititions(romanNumeral);

            var numerals = new Queue(romanNumeral.ToCharArray());

            var runningTotal = 0;
            while (numerals.Count > 0)
            {
                var numeralValue = GetNumeralValue(numerals.Dequeue());

                if (numerals.Count >= 1 && IsSubractiveNumeral(numeralValue, GetNumeralValue(numerals.Peek())))
                    runningTotal -= numeralValue;
                else
                    runningTotal += numeralValue;
            }

            return runningTotal;
        }

        private static bool IsSubractiveNumeral(int numeralValue, int nextNumeral)
        {
            return numeralValue < nextNumeral;
        }

        private static int GetNumeralValue(object numeral)
        {
            Guard.AgainstIllegalCharacters(numeral.ToString());
            return (int)Enum.Parse(typeof(Numerals), numeral.ToString(), true);
        }

        private static class Guard
        {
            public static void AgainstIllegalCharacters(string numeralCharacter)
            {
                if(!Enum.IsDefined(typeof(Numerals), numeralCharacter.ToUpper()))
                    throw new ArgumentException("Illegal numeral character");
            }

            public static void AgainstIllegalNumeralRepititions(string numeral)
            {
                var numeralCharacters = numeral.ToCharArray();
                var testCharacter = numeralCharacters.First();
                var repetitions = 0;

                foreach (var character in numeralCharacters)
                {
                    if (character.Equals(testCharacter))
                    {
                        repetitions++;
                        if(repetitions > Enum.Parse<Numerals>(character.ToString(), true).GetAllowedRepetitions())
                            throw new ArgumentException("Illegal number of character repetitions for " + character);
                    }
                    else
                    {
                        testCharacter = character;
                    }

                }
            }
        }
    }
}
