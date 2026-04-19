using System;

namespace PEMSApi.Models.DTOs;

public class PagedResponseDto<T>
{
    public List<T> Data { get; set; }
    public int TotalRecords { get; set; }
    public int CurrentPage { get; set; }
    public int PageSize { get; set; }
    public int TotalPages { get; set; }
    public decimal TotalIncome { get; set; }
    public decimal TotalExpense { get; set; }
    public decimal Balance { get; set; }
}
