using System.Collections;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PEMSApi.Data;
using PEMSApi.Service;
using Transaction = PEMSApi.Models.Transaction;

namespace PEMSApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransactionsController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly ITransactionService _transactionService;

        public TransactionsController(AppDbContext context, ITransactionService transactionService)
        {
            _context = context;
            _transactionService = transactionService;
        }

        [HttpGet]
        public async Task<IActionResult> GetTransactions([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            var getAllTransactions = await _transactionService.GetAllTransactionAsync(pageNumber, pageSize);
            return Ok(getAllTransactions);
        }

        [HttpGet("categories")]
        public async Task<IActionResult> GetCategories()
        {
            var categories = await _context.Categories.ToListAsync();

            return Ok(categories);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTransaction([FromBody] Transaction transaction)
        {
            if (transaction.Amount <= 0) return BadRequest("Số tiền phải > 0");

            var categoryExists = await _context.Categories.AnyAsync(c => c.Id == transaction.CategoryId);
            if (!categoryExists) return BadRequest("Danh mục không tồn tại");

            if (transaction.TransactionDate == default)
            {
                transaction.TransactionDate = DateTime.UtcNow;
            }
            else
            {
                // Ép kiểu về utc để  postgresql chịu lưu
                transaction.TransactionDate = transaction.TransactionDate.ToUniversalTime();
            }

            _context.Transactions.Add(transaction);
            await _context.SaveChangesAsync();

            return StatusCode(201, transaction);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTransaction(int id)
        {
            var transaction = await _context.Transactions.FindAsync(id);
            if (transaction == null) return NotFound("Không tìm thấy");

            _context.Transactions.Remove(transaction);
            await _context.SaveChangesAsync();
            return Ok("Xóa thành công");
        }
    }
}