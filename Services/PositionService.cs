// Services/PositionService.cs
using PositionManagementApi.Data;
using PositionManagementApi.Models;
using Microsoft.EntityFrameworkCore;

namespace PositionManagementApi.Services;

public class PositionService
{
    private readonly PositionDbContext _dbContext;

    public PositionService(PositionDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddTransactionAsync(Transaction transaction)
    {
        _dbContext.Transactions.Add(transaction);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<List<Position>> GetPositionsAsync()
    {
        var transactions = await _dbContext.Transactions.ToListAsync();

        var latestByTradeId = transactions
            .GroupBy(t => t.TradeId)
            .Select(g => g.OrderByDescending(t => t.Version).First())
            .Where(t => t.Action != "CANCEL");

        var result = new Dictionary<string, int>();

        foreach (var t in latestByTradeId)
        {
            int qty = t.BuySell == "Buy" ? t.Quantity : -t.Quantity;

            if (result.ContainsKey(t.SecurityCode))
                result[t.SecurityCode] += qty;
            else
                result[t.SecurityCode] = qty;
        }

        return result.Select(r => new Position
        {
            SecurityCode = r.Key,
            NetQuantity = r.Value
        }).ToList();
    }
}
