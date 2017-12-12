namespace RomanCalculator.Core.Data
{
    public static class NumeralExtensions
    {
        public static int GetAllowedRepetitions(this Numerals numeral)
        {
            switch (numeral)
            {
                case Numerals.V:
                case Numerals.L:
                case Numerals.D:
                    return 1;
                case Numerals.I:
                case Numerals.X:
                case Numerals.C:
                case Numerals.M:
                    return 3;
                default:
                    return 0;
            }

        }
    }
}