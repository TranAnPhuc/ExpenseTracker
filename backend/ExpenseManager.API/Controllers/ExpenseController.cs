using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ExpenseManager.API.DTOs;
using ExpenseManager.API.DTOs.Expense;
using ExpenseManager.API.Models;
using ExpenseManager.API.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ExpenseManager.API.Controllers
{
    [ApiController]
    [Route("api/expenses")]
    public class ExpenseController : ControllerBase
    {
        private readonly IExpenseService _service;

        public ExpenseController(IExpenseService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var expense = await _service.GetAllAsync();
            return Ok(ApiResponse<List<Expense>>.Ok(expense));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetExpenseByIdAsync(int id)
        {
            var expense = await _service.GetByIdAsync(id);

            return Ok(ApiResponse<Expense>.Ok(expense));
        } 

        [HttpPost]
        public async Task<IActionResult> CreateExpenseAsync([FromBody] CreateExpenseDto dto)
        {
            var expense = new Expense
            {
                Description = dto.Description,
                Amount = dto.Amount,
                Date = dto.Date,
                CategoryId = dto.CategoryId
            };

            var created = await _service.CreateAsync(expense);
            return Created($"api/expenses/{expense.Id}",ApiResponse<Expense>.Ok(created,"Tạo chi tiêu thành công"));
        }
    }
}