using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExpenseManager.API.Models;

namespace ExpenseManager.API.Repositories
{
    public interface IExpenseRepository
    {
        Task<List<Expense>> GetAllByUserAsync(int userId);
        Task<Expense?> GetByIdAsync(int id);
        Task AddAsync(Expense expense);
    }
}