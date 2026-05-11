using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ExpenseManager.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExpenseController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            var expenses = new[]
            {
                new { Id = 1, Description = "Groceries", Amount = 150.00, Date = DateTime.Now.AddDays(-2) },
                new { Id = 2, Description = "Electricity Bill", Amount = 75.50, Date = DateTime.Now.AddDays(-10) },
                new { Id = 3, Description = "Internet Bill", Amount = 60.00, Date = DateTime.Now.AddDays(-5) }
            };

            return Ok(expenses);
        }
    }
}