using GithubActionBuildTests.DAL;
using GithubActionBuildTests.Domain;
using GithubActionBuildTests.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GithubActionBuildTests.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DBController : ControllerBase
    {
        private CalculatorRepository _repo { get; set; }

        public DBController(CalculatorRepository repo)
        {
            _repo = repo;
        }

        [HttpGet("v1/susm")]
        public async Task<IActionResult> Sum([FromQuery] int a, [FromQuery] int b)
        {
            var calc = new Calculator(a, b);
            var summary = new SummaryCalc("sum", a, b);
            summary=await _repo.AddAsync(summary);
            await _repo.SaveAsync();
            return Ok(calc.Sum());
        }

        [HttpGet("v1/min")]
        public async Task<IActionResult> Min([FromQuery] int a, [FromQuery] int b)
        {
            var calc = new Calculator(a, b);
            var summary = new SummaryCalc("min", a, b);
            summary = await _repo.AddAsync(summary);
            await _repo.SaveAsync();
            return Ok(calc.Min());
        }

        [HttpGet("v1/all")]
        public async Task<IActionResult> All()
        {
            return Ok(await _repo.GetAll().ToListAsync());
        }
    }
}
