using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExpenseManager.API.Models;

namespace ExpenseManager.API.Services
{
    public interface IExpenseService
    {
        Task<List<Expense>> GetAllAsync();
        Task<Expense> GetByIdAsync(int id);
        Task<Expense> CreateAsync(Expense expense);
    }
}