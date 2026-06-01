using InventorySystem.Application.Services;
using InventorySystem.Domain.Interfaces;
using InventorySystem.Infrastructure.Data;
using InventorySystem.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Database configuration
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// Unit of Work and Repository pattern configuration
// Scoped one instance per request
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// Services configuration
builder.Services.AddScoped<IProductService, ProductService>();

// Controllers configuration + swagger configuration
builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();

// CORS - Allowa Blazor to call this API
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    policy.AllowAnyOrigin()
          .AllowAnyMethod()
          .AllowAnyHeader());
});

var app = builder.Build();

// Middleware configuration
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
// Use CORS policy
app.UseCors("AllowAll");
app.UseAuthorization();
app.MapControllers();

app.Run();