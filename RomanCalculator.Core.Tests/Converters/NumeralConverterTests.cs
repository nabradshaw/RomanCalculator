using System;
using FluentAssertions;
using RomanCalculator.Core.Converters;
using Xunit;

namespace RomanCalculator.Core.Tests.Converters
{
    public class NumeralConverterTests
    {

        [Fact]
        public void ConvertToArabic_WhenPassedIReturns1()
        {
            const string numeral = "I";
            var expected = 1;

            var result = NumeralConverter.ToArabic(numeral);

            result.Should().Be(expected);
        }

        [Fact]
        public void ConvertToArabic_WhenPassedIIReturns2()
        {
            const string numeral = "II";
            var expected = 2;

            var result = NumeralConverter.ToArabic(numeral);

            result.Should().Be(expected);
        }

        [Fact]
        public void ConvertToArabic_WhenPassedNonSubtractiveNumeral_ReturnsCorrectIntegerValue()
        {
            const string numeral = "XXV";
            var expected = 25;

            var result = NumeralConverter.ToArabic(numeral);

            result.Should().Be(expected);
        }

        [Fact]
        public void ConvertToArabic_WhenPassedSubtractiveNumeral_ReturnsCorrectIntegerValue()
        {
            const string numeral = "IV";
            var expected = 4;

            var result = NumeralConverter.ToArabic(numeral);

            result.Should().Be(expected);
        }

        [Fact]
        public void ConvertToArabic_CaseIsIgnored()
        {
            const string numeral = "xxV";
            var expected = 25;

            var result = NumeralConverter.ToArabic(numeral);

            result.Should().Be(expected);
        }

        [Fact]
        public void ConvertToArabic_WhenPassedNumeralWithIllegalCharacters_Throws()
        {
            const string badNumeral = "WAT";

            Assert.Throws<ArgumentException>(() => NumeralConverter.ToArabic(badNumeral));
        }

        [Fact]
        public void ConvertToArabic_WhenPassedNumeralWithIllegalCharacterRepetitions_Throws()
        {
            const string numeral1 = "IIII";
            const string numeral2 = "DD";
            const string numeral3 = "VIIII";

            Assert.Throws<ArgumentException>(() => NumeralConverter.ToArabic(numeral1));
            Assert.Throws<ArgumentException>(() => NumeralConverter.ToArabic(numeral2));
            Assert.Throws<ArgumentException>(() => NumeralConverter.ToArabic(numeral3));
        }
    }
}