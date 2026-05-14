using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseManager.API.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Tên danh mục không được để trống")]
        [MaxLength(100,ErrorMessage ="Tên danh mục không vượt quá 100 ký tự")]
        public string Name { get; set; } = string.Empty;

        [MaxLength(255)]
        public string? Description { get; set; }

        public ICollection<Expense> Expenses {get;set;} = new List<Expense>();

    }
}