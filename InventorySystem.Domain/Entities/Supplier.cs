using InventorySystem.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace InventorySystem.Domain.Entities;

public class Supplier : BaseEntity
{
    public string CompanyName { get; set; } = string.Empty;

    public string ContactName { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    // Navigation property for 1 to many relationship (One supplier has many products)
    public ICollection<Product> Products { get; set; } = new List<Product>();
}