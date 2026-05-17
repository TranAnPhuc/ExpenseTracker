using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ExpenseManager.API.DTOs;
using ExpenseManager.API.DTOs.Expense;
using ExpenseManager.API.Exceptions;
using ExpenseManager.API.Models;
using ExpenseManager.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ExpenseManager.API.Controllers
{
    [ApiController]
    [Route("api/expenses")]
    [Authorize]
    public class ExpenseController : ControllerBase
    {
        private readonly IExpenseService _service;

        public ExpenseController(IExpenseService service)
        {
            _service = service;
        }

        private int GetCurrentUserId()
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim == null)
                throw new BusinessException("Không xác định được người dùng");

            return int.Parse(userIdClaim.Value);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var userId = GetCurrentUserId();
            var expense = await _service.GetAllByUserAsync(userId);
            return Ok(ApiResponse<List<Expense>>.Ok(expense));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetExpenseByIdAsync(int id)
        {
            var userId = GetCurrentUserId();
            var expense = await _service.GetByIdAsync(id, userId);

            return Ok(ApiResponse<Expense>.Ok(expense));
        }

        [HttpPost]
        public async Task<IActionResult> CreateExpenseAsync([FromBody] CreateExpenseDto dto)
        {
            var userId = GetCurrentUserId();
            var expense = new Expense
            {
                Description = dto.Description,
                Amount = dto.Amount,
                Date = dto.Date,
                CategoryId = dto.CategoryId,
                UserId = userId
            };

            var created = await _service.CreateAsync(expense);
            return Created($"api/expenses/{expense.Id}", ApiResponse<Expense>.Ok(created, "Tạo chi tiêu thành công"));
        }
    }
}