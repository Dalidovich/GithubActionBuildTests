using GithubActionBuildTests.Domain.Models;
using System.Security.Principal;

namespace GithubActionBuildTests.DAL
{
    public class CalculatorRepository
    {
        private readonly AppDBContext _db;

        public CalculatorRepository(AppDBContext db)
        {
            _db = db;
        }

        public async Task<SummaryCalc> AddAsync(SummaryCalc entity)
        {
            var createdEntity = await _db.SummaryCalcs.AddAsync(entity);

            return createdEntity.Entity;
        }

        public bool Delete(SummaryCalc entity)
        {
            _db.SummaryCalcs.Remove(entity);

            return true;
        }

        public IQueryable<SummaryCalc> GetAll()
        {

            return _db.SummaryCalcs;
        }

        public async Task<bool> SaveAsync()
        {
            await _db.SaveChangesAsync();

            return true;
        }
    }
}
