using Microsoft.AspNetCore.Mvc;
using PositionManagementApi.Models;
using PositionManagementApi.Services;

namespace PositionManagementApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TransactionsController : ControllerBase
{
    private readonly PositionService _positionService;

    public TransactionsController(PositionService positionService)
    {
        _positionService = positionService;
    }

    [HttpPost]
    public async Task<IActionResult> AddTransaction([FromBody] Transaction transaction)
    {
        await _positionService.AddTransactionAsync(transaction);
        return Ok();
    }

    [HttpGet("/api/positions")]
    public async Task<IActionResult> GetPositions()
    {
        var positions = await _positionService.GetPositionsAsync();
        return Ok(positions);
    }

}
