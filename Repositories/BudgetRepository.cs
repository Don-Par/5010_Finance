using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PersonalFinanceTracker.Database;
using PersonalFinanceTracker.Models;

namespace PersonalFinanceTracker.Repositories
{
    public class BudgetRepository : IBudgetRepository
    {
        private readonly FinanceDbContext _dbContext;

        public BudgetRepository(FinanceDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Budget>> GetAllBudgetsAsync()
        {
            return await _dbContext.Budgets.ToListAsync();
        }

        public async Task<Budget?> GetBudgetByIdAsync(int id)
        {
            return await _dbContext.Budgets.FindAsync(id);
        }

        public async Task AddBudgetAsync(Budget budget)
        {
            await _dbContext.Budgets.AddAsync(budget);
            await _dbContext.SaveChangesAsync();
        }
    }
}
