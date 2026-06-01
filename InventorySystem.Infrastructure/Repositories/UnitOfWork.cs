using InventorySystem.Domain.Entities;
using InventorySystem.Domain.Interfaces;
using InventorySystem.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace InventorySystem.Infrastructure.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;

    private IRepository<Product>? _Product;
    private IRepository<Category>? _category;
    private IRepository<Supplier>? _supplier;
    private IRepository<StockMovement>? _stockMovement;

    public UnitOfWork(AppDbContext context)
    {
        this._context = context;
    }

    public IRepository<Product> Products => _Product ??= new GenericRepository<Product>(_context);

    public IRepository<Category> Categories => _category ??= new GenericRepository<Category>(_context);

    public IRepository<Supplier> Suppliers => _supplier ??= new GenericRepository<Supplier>(_context);

    public IRepository<StockMovement> StockMovements => _stockMovement ??= new GenericRepository<StockMovement>(_context);

    public Task<int> SaveChnagesAsync() => _context.SaveChangesAsync();

    public void Dispose() => _context.Dispose();
}