using GithubActionBuildTests.DAL;
using GithubActionBuildTests.Domain;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace GithubActionBuildTests
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            //builder.Services.AddHostedService<CheckDBHostedService>();

            builder.Services.AddScoped<CalculatorRepository>();

            builder.Services.Configure<TestValues>(builder.Configuration.GetSection("TestValues"));
            builder.Services.AddSingleton(serviceProvider => serviceProvider.GetRequiredService<IOptions<TestValues>>().Value);

            builder.Services.AddDbContext<AppDBContext>(opt => opt.UseNpgsql(
                builder.Configuration.GetConnectionString(StandartConst.NameConnection)));

            var app = builder.Build();
            if (app.Environment.IsProduction() || app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseMiddleware<CheckDBMiddleware>();

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}