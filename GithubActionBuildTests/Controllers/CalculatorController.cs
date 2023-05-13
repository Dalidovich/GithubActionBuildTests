using GithubActionBuildTests.Models;
using Microsoft.AspNetCore.Mvc;

namespace GithubActionBuildTests.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculatorController : ControllerBase
    {
        [HttpGet("sum")]
        public async Task<IActionResult> Sum([FromQuery] int a, [FromQuery] int b)
        {
            var calc = new Calculator(a, b);
            return Ok(calc.Sum());
        }

        [HttpGet("min")]
        public async Task<IActionResult> Min([FromQuery] int a, [FromQuery] int b)
        {
            var calc = new Calculator(a, b);
            return Ok(calc.Min());
        }

        [HttpGet("div")]
        public async Task<IActionResult> Div([FromQuery] int a, [FromQuery] int b)
        {
            var calc = new Calculator(a, b);
            return Ok(calc.Div());
        }

        [HttpGet("mult")]
        public async Task<IActionResult> Mult([FromQuery] int a, [FromQuery] int b)
        {
            var calc = new Calculator(a, b);
            return Ok(calc.Mult());
        }

        [HttpGet("max")]
        public async Task<IActionResult> Max([FromQuery] int a, [FromQuery] int b)
        {
            var calc = new Calculator(a, b);
            return Ok(calc.Max());
        }
    }
}