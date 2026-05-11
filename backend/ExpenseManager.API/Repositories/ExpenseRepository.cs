using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExpenseManager.API.Models;

namespace ExpenseManager.API.Repositories
{
    public class ExpenseRepository : IExpenseRepository
    {
        private static List<Expense> _expense = new List<Expense>
        {
            new Expense { Id = 1, Description = "Groceries", Amount = 150.00m, Date = DateTime.Now.AddDays(-2) },
            new Expense { Id = 2, Description = "Electricity Bill", Amount = 75.50m, Date = DateTime.Now.AddDays(-10) },
            new Expense { Id = 3, Description = "Internet Bill", Amount = 60.00m, Date = DateTime.Now.AddDays(-5) }
        };

        public List<Expense> GetAll()
        {
            return _expense;
        }

        public Expense GetById(int id)
        {
            return _expense.FirstOrDefault(expense => expense.Id == id);
        }

        public void Add(Expense expense)
        {
            _expense.Add(expense);
        }
    }
}