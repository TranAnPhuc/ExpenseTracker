using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExpenseManager.API.Models;

namespace ExpenseManager.API.Services
{
    public interface ICategoryService
    {
        List<Category> GetAll();
        Category? GetById(int id);
        Category Create(Category category);
    }
}