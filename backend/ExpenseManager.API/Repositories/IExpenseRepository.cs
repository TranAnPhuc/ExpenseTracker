using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExpenseManager.API.Models;

namespace ExpenseManager.API.Repositories
{
    public interface IExpenseRepository
    {
        List<Expense> GetAll();
        Expense GetById(int id);
        void Add(Expense expense);
    }
}