using InventorySystem.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace InventorySystem.Domain.Entities;

public class Category : BaseEntity
{
    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    // NAvogation property for 1 to many relationship (One category has many prodcuts)
    public ICollection<Product> Products { get; set; } = new List<Product>();
}