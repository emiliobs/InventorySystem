using InventorySystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace InventorySystem.Domain.Interfaces;

// Coordinates all repository operations into a single transaction
public interface IUnitOfWork : IDisposable
{
    IRepository<Product> Products { get; }
    IRepository<Category> Categories { get; }
    IRepository<Supplier> Suppliers { get; }
    IRepository<StockMovement> StockMovements { get; }

    Task<int> SaveChnagesAsync();
}