using FluentAssertions;
using GithubActionBuildTests.Domain.Models;
using Xunit;

namespace GithubActionBuildTests.Test
{
    public class CalculatorTest
    {
        [Fact]
        public async Task SumTest()
        {
            int a = 6;
            int b = 2;

            var expResult = 8;
            var calculator = new Calculator(a,b);
            var result = calculator.Sum();

            result.Should().Be(expResult);
        }

        [Fact]
        public async Task MinimumTest()
        {
            int a = 6;
            int b = 2;

            var expResult = 2;
            var calculator = new Calculator(a, b);
            var result = calculator.Minimum();

            result.Should().Be(expResult);
        }
    }
}