using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExpenseManager.API.Exceptions;
using ExpenseManager.API.Models;
using ExpenseManager.API.Repositories;

namespace ExpenseManager.API.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repository;

        public CategoryService(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Category>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Category?> GetByIdAsync(int id)
        {
            var category = await _repository.GetByIdAsync(id);
            if(category == null)
                throw new NotFoundException("danh mục",id);
            return category;
        }

        public async Task<Category> CreateAsync(Category category)
        {
            await _repository.AddAsync(category);
            return category;
        }
    }
}