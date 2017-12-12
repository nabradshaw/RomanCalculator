using System;
using FluentAssertions;
using RomanCalculator.Core.Converters;
using Xunit;

namespace RomanCalculator.Core.Tests.Converters
{
    public class ArabicConverterTests
    {

        [Fact]
        public void ConvertArabicToNumeral_WhenPassedA1_ReturnsI()
        {
            const int number = 1;
            const string expected = "I";


            var result = ArabicConverter.ToNumeral(number);

            result.Should().Be(expected);
        }

        [Fact]
        public void ConvertArabicToNumeral_WhenPassed5_ReturnsV()
        {
            const int number = 5;
            const string expected = "V";

            var result = ArabicConverter.ToNumeral(number);

            result.Should().Be(expected);
        }

        [Fact]
        public void ConvertArabicToNumeral_WhenPassedABaseValue_ReturnsTheCorrectNumeral()
        {
            const int number = 10;
            const string expected = "X";

            var result = ArabicConverter.ToNumeral(number);

            result.Should().Be(expected);
        }

        [Fact]
        public void ConvertArabicToNumeral_WhenPassedANonBaseValue_ReturnsTheCorrectNumeral()
        {
            const int number = 19;
            const string expected = "XIX";

            var result = ArabicConverter.ToNumeral(number);

            result.Should().Be(expected);
        }

        [Fact]
        public void ConvertArabicToNumeral_WhenPassedANumberUnderMinimum_Throws()
        {
            const int underMinimum = ArabicConverter.MinimumNumeralValue - 1;

            Assert.Throws<ArgumentOutOfRangeException>(() => ArabicConverter.ToNumeral(underMinimum));
        }

        [Fact]
        public void ConvertArabicToNumeral_WhenPassedANumberOverMaximum_Throws()
        {
            const int overMaximum = ArabicConverter.MaximumNumeralValue + 1;

            Assert.Throws<ArgumentOutOfRangeException>(() => ArabicConverter.ToNumeral(overMaximum));
        }

    }
}