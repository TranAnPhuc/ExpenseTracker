using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExpenseManager.API.Models;
using ExpenseManager.API.Repositories;

namespace ExpenseManager.API.Services
{
    public class ExpenseService : IExpenseService
    {
        private readonly IExpenseRepository _repository;

        public ExpenseService(IExpenseRepository repository)
        {
            _repository = repository;
        }

        public List<Expense> GetAll()
        {
            return _repository.GetAll();
        }

        public Expense GetById(int id)
        {
            return _repository.GetById(id);
        }

        public Expense Create(Expense expense)
        {
            if(expense.Amount <= 0)
                throw new ArgumentException("Số tiền phải lớn hơn 0");

            if(expense.Date > DateTime.Now)
                throw new ArgumentException("Ngày chi tiêu không được ở tương lai");
            
            expense.Id = new Random().Next(100,999);
            
            _repository.Add(expense);

            return expense;
        }
    }
}
