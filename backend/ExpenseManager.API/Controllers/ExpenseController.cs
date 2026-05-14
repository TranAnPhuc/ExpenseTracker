using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
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
            return Ok(expense);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetExpenseByIdAsync(int id)
        {
            var expense = await _service.GetByIdAsync(id);

            if(expense == null)
            {
                return NotFound(new {message = "Không có khoản chi được tìm thấy"});
            }

            return Ok(expense);
        } 

        [HttpPost]
        public async Task<IActionResult> CreateExpenseAsync([FromBody] Expense expense)
        {
            try
            {
                var created = await _service.CreateAsync(expense);
                return Created($"api/expenses/{expense.Id}",created);
            }
            catch(ArgumentException ex)
            {
                return BadRequest(new {message = ex.Message});
            }
        }
    }
}