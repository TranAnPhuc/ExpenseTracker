using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExpenseManager.API.Models;
using Microsoft.EntityFrameworkCore;

namespace ExpenseManager.API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){}

        public DbSet<Category> Categories {get;set;}
        public DbSet<Expense> Expenses {get;set;}
        public DbSet<User> Users {get;set;}
    }
}