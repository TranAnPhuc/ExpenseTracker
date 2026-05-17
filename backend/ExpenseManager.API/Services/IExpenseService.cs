using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExpenseManager.API.Models;

namespace ExpenseManager.API.Services
{
    public interface IExpenseService
    {
        Task<List<Expense>> GetAllByUserAsync(int userId);
        Task<Expense?> GetByIdAsync(int id, int userID);
        Task<Expense> CreateAsync(Expense expense);
    }
}