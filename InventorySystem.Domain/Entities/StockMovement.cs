using InventorySystem.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace InventorySystem.Domain.Entities;

public class StockMovement : BaseEntity
{
    // IN for adding stock , OUT for removing stock
    public string MovementType { get; set; } = string.Empty;

    public int Quantity { get; set; }
    public string Reason { get; set; } = string.Empty;

    // Foreing Key
    public int ProductId { get; set; }

    public Product? Product { get; set; }
}