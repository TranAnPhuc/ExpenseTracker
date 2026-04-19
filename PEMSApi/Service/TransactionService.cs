using System;
using Microsoft.EntityFrameworkCore;
using PEMSApi.Data;
using PEMSApi.Models.DTOs;

namespace PEMSApi.Service;

public class TransactionService : ITransactionService
{
    private readonly AppDbContext _context;

    public TransactionService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<PagedResponseDto<TransactionResponseDto>> GetAllTransactionAsync(int pageNumber, int pageSize)
    {
        // Calculate income, expense, balance
        var totalIncome = await _context.Transactions
                            .Include(t => t.Category)
                            .Where(t => t.Category!.Type == false)
                            .SumAsync(t => t.Amount);

        var totalExpense = await _context.Transactions
                .Include(t => t.Category)
                .Where(t => t.Category!.Type == true)
                .SumAsync(t => t.Amount);

        var balance = totalIncome - totalExpense;

        // Pagination
        var skipAmount = (pageNumber - 1) * pageSize;

        var transactions = await _context.Transactions
            .Include(t => t.Category)
            .OrderByDescending(t => t.TransactionDate)
            .Skip(skipAmount)
            .Take(pageSize)
            .Select(t => new TransactionResponseDto
            {
                Id = t.Id,
                Amount = t.Amount,
                CategoryName = t.Category != null ? t.Category.Name : "Khong xac dinh",
                TransactionDate = t.TransactionDate
            })
            .ToListAsync();

        var totalRecords = await _context.Transactions.CountAsync();

        PagedResponseDto<TransactionResponseDto> response = new PagedResponseDto<TransactionResponseDto>
        {
            Data = transactions,
            TotalRecords = totalRecords,
            CurrentPage = pageNumber,
            PageSize = pageSize,
            TotalPages = (int)Math.Ceiling(totalRecords / (double)pageSize),
            TotalIncome = totalIncome,
            TotalExpense = totalExpense,
            Balance = balance
        };

        return response;
    }
}
