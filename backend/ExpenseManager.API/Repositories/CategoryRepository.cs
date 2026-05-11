using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExpenseManager.API.Models;

namespace ExpenseManager.API.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private static List<Category> _categories = new List<Category>
        {
            new Category { Id = 1, Name = "Mua sắm",  Description = "Quần áo" },
            new Category { Id = 2, Name = "Đi chợ",   Description = "Mua cá"  },
            new Category { Id = 3, Name = "Đi chơi",  Description = "Đầm sen" }
        };

        public List<Category> GetAll()
        {
            return _categories;
        }

        public Category GetById(int id)
        {
            return _categories.FirstOrDefault(category => category.Id == id);
        }
        
        public void Add(Category category)
        {
            _categories.Add(category);
        }
    }
}