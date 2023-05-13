using FluentAssertions;
using GithubActionBuildTests.Controllers;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace GithubActionBuildTests.Test
{
    public class CalculatorControllerTest
    {
        [Fact]
        public async Task SumTest()
        {
            int a = 6;
            int b = 2;

            var expResult = 8;
            var controller = new CalculatorController();
            var result = await controller.Sum(a,b) as OkObjectResult;
            var num = (int)result.Value;

            num.Should().Be(expResult);
        }

        [Fact]
        public async Task MaxTest()
        {
            int a = 6;
            int b = 2;

            var expResult = 6;
            var controller = new CalculatorController();
            var result = await controller.Max(a, b) as OkObjectResult;
            var num = (int)result.Value;

            num.Should().Be(expResult);
        }
    }
}