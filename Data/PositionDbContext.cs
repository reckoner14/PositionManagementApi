// Data/PositionDbContext.cs
using Microsoft.EntityFrameworkCore;
using PositionManagementApi.Models;

namespace PositionManagementApi.Data;

public class PositionDbContext : DbContext
{
    public PositionDbContext(DbContextOptions<PositionDbContext> options) : base(options) { }

    public DbSet<Transaction> Transactions { get; set; }
}
