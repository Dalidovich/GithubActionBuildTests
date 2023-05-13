using FluentAssertions;
using GithubActionBuildTests.Models;
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
        public async Task MaxTest()
        {
            int a = 6;
            int b = 2;

            var expResult = 6;
            var calculator = new Calculator(a, b);
            var result = calculator.Max();

            result.Should().Be(expResult);
        }
    }
}