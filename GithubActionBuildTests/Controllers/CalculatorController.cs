using GithubActionBuildTests.Domain;
using GithubActionBuildTests.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace GithubActionBuildTests.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculatorController : ControllerBase
    {
        [HttpGet("v1/test")]
        public IActionResult Get() 
        {
            var s = new SummaryCalc("test", 3, 8);
            return Ok(s);
        }


        [HttpGet("v1/sum")]
        public IActionResult Sum([FromQuery] int a, [FromQuery] int b)
        {
            var calc = new Calculator(a, b);
            return Ok(calc.Sum());
        }

        [HttpGet("v1/min")]
        public IActionResult Min([FromQuery] int a, [FromQuery] int b)
        {
            var calc = new Calculator(a, b);
            return Ok(calc.Min());
        }

        [HttpGet("v1/div")]
        public IActionResult Div([FromQuery] int a, [FromQuery] int b)
        {
            var calc = new Calculator(a, b);
            return Ok(calc.Div());
        }

        [HttpGet("v1/mult")]
        public IActionResult Mult([FromQuery] int a, [FromQuery] int b)
        {
            var calc = new Calculator(a, b);
            return Ok(calc.Mult());
        }

        [HttpGet("v1/minimum")]
        public IActionResult Minimum([FromQuery] int a, [FromQuery] int b)
        {
            var calc = new Calculator(a, b);
            return Ok(calc.Minimum());
        }

        [HttpGet("v1/Envvars")]
        public IActionResult EnvVar()
        {
            var values = HttpContext.RequestServices.GetService<TestValues>();
            return Ok(values);
        }
    }
}