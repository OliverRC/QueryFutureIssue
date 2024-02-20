using AspireApp1.ApiService;
using Microsoft.AspNetCore.Mvc;
using Z.EntityFramework.Plus;

var builder = WebApplication.CreateBuilder(args);

// Add service defaults & Aspire components.
builder.AddServiceDefaults();

// Add services to the container.
builder.Services.AddProblemDetails();

// Add the ef core database context, via the aspire implementation
// MySql / MariaDB
// builder.AddMySqlDbContext<AppDbContext>("AppDatabaseMySql");
// MSSQL
builder.AddSqlServerDbContext<AppDbContext>("AppDatabaseSqlServer");

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseExceptionHandler();

app.MapGet("/people", (AppDbContext dbContext, 
    [FromQuery] int page = 1, 
    [FromQuery] int pageSize = 10) =>
{
    var query = dbContext.People.AsQueryable();

    var futureItems = query.Skip((page - 1) * pageSize)
        .Take(pageSize)
        .Future();
    
    var futureCount = query.DeferredCount().FutureValue();
    
    var items = futureItems.ToList();
    var count = futureCount.Value;
    
    return new { count, items };
});

app.MapDefaultEndpoints();

app.Run();