using InventorySystem.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace InventorySystem.Domain.Entities;

public class Product : BaseEntity
{
    public string Name { get; set; } = string.Empty;

    public string Barcode { get; set; } = string.Empty;

    public decimal Price { get; set; }

    public int Stock { get; set; }

    // Foreign key to connect tables
    public int CategoryId { get; set; }

    public Category? Category { get; set; }

    public int SupplierId { get; set; }
    public Supplier? Supplier { get; set; }

    // Master detail relationship (1 Prodcut has many stock movements)
    public ICollection<StockMovement> StockMovements { get; set; } = new List<StockMovement>();
}