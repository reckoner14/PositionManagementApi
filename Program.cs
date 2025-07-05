using Microsoft.EntityFrameworkCore;
using PositionManagementApi.Data;
using PositionManagementApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Register InMemory EF Core
builder.Services.AddDbContext<PositionDbContext>(options =>
    options.UseInMemoryDatabase("PositionDb"));

// Register service (refactored to use DB)
builder.Services.AddScoped<PositionService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
