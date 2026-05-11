using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExpenseManager.API.Models;

namespace ExpenseManager.API.Services
{
    public interface IExpenseService
    {
        List<Expense> GetAll();
        Expense GetById(int id);
        Expense Create(Expense expense);
    }
}