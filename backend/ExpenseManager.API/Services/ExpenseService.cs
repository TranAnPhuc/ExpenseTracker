using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExpenseManager.API.Exceptions;
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

        public async Task<List<Expense>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Expense?> GetByIdAsync(int id)
        {
            var expense = await _repository.GetByIdAsync(id);
            if(expense == null)
                throw new NotFoundException("chi tiêu",id);
            return expense;
        }

        public async Task<Expense> CreateAsync(Expense expense)
        {
            if(expense.Amount <= 0)
                throw new BusinessException("Số tiền phải lớn hơn 0");

            if(expense.Date > DateTime.Now)
                throw new BusinessException("Ngày chi tiêu không được ở tương lai");
            
            await _repository.AddAsync(expense);

            return expense;
        }
    }
}
