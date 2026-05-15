using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseManager.API.DTOs.Expense
{
    public class CreateExpenseDto
    {
        [Required(ErrorMessage ="Mô tả không được để trống")]
        [MaxLength(255)]
        public string Description { get; set; } = string.Empty;
        [Required]
        public decimal Amount { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        [Required]
        public int CategoryId { get; set; }
    }
}