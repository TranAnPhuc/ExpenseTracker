using System;
using PEMSApi.Models.DTOs;

namespace PEMSApi.Service;

public interface ITransactionService
{
    Task<PagedResponseDto<TransactionResponseDto>> GetAllTransactionAsync(int pageNumber, int pageSize);
}
