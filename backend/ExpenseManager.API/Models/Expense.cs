using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseManager.API.Models
{
    public class Expense
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Mô tả không được để trống")]
        [MaxLength(255)]
        public string Description { get; set; }
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public int CategoryId { get; set; }
        public Category? Category {get;set;}
    }
}