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
        public IActionResult GetAll()
        {
            var expense = _service.GetAll();
            return Ok(expense);
        }

        [HttpGet("{id}")]
        public IActionResult GetExpenseById(int id)
        {
            var expense = _service.GetById(id);

            if(expense == null)
            {
                return NotFound(new {message = "Không có khoản chi được tìm thấy"});
            }

            return Ok(expense);
        } 

        [HttpPost]
        public IActionResult CreateExpense([FromBody] Expense expense)
        {
            try
            {
                var created = _service.Create(expense);
                return Created($"api/expenses/{expense.Id}",created);
            }
            catch(ArgumentException ex)
            {
                return BadRequest(new {message = ex.Message});
            }
        }
    }
}