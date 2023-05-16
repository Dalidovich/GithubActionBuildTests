using GithubActionBuildTests.DAL;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace GithubActionBuildTests
{
    public class CheckDBMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<CheckDBMiddleware> _logger;

        public CheckDBMiddleware(RequestDelegate next,
            ILogger<CheckDBMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                if (!await httpContext.RequestServices.GetService<AppDBContext>().SummaryCalcs.AnyAsync())
                {
                    httpContext.RequestServices.GetService<AppDBContext>().UpdateDatabase();
                }
            }
            catch (PostgresException ex)
            {
                if (ex.Code == "42P01")
                {
                    httpContext.RequestServices.GetService<AppDBContext>().UpdateDatabase();
                }
                throw ex;
            }
            await _next.Invoke(httpContext);
        }
    }
}