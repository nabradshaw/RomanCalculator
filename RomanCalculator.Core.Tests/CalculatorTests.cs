using FluentAssertions;
using Xunit;

namespace RomanCalculator.Core.Tests
{
    public class CalculatorTests
    {
        [Fact]
        public void Add_WhenPassedIAndI_ReturnsII()
        {
            const string input1 = "I";
            const string input2 = "I";
            const string expected = "II";

            var result = Calculator.Add(input1, input2);

            result.Should().Be(expected);
        }

        [Fact]
        public void Add_WhenPassedIAndII_ReturnsIII()
        {
            const string input1 = "I";
            const string input2 = "II";
            const string expected = "III";

            var result = Calculator.Add(input1, input2);

            result.Should().Be(expected);

        }

        [Fact]
        public void Add_WhenPassedIIAndII_ReturnsIV()
        {
            const string input1 = "II";
            const string input2 = "II";
            const string expected = "IV";

            var result = Calculator.Add(input1, input2);

            result.Should().Be(expected);

        }

        [Fact]
        public void Add_WhenPassedIVAndIX_ReturnsXIII()
        {
            const string input1 = "IV";
            const string input2 = "IX";
            const string expected = "XIII";

            var result = Calculator.Add(input1, input2);

            result.Should().Be(expected);

        }

        [Fact]
        public void Add_WhenPassedMCAndMC_ReturnsMMCC()
        {
            const string input1 = "MC";
            const string input2 = "MC";
            const string expected = "MMCC";

            var result = Calculator.Add(input1, input2);

            result.Should().Be(expected);

        }

        [Fact]
        public void Add_IsCommutative()
        {
            const string input1 = "VIII";
            const string input2 = "XII";

            var result1 = Calculator.Add(input1, input2);
            var result2 = Calculator.Add(input2, input1);

            result1.Should().Be(result2);
        }
    }
}