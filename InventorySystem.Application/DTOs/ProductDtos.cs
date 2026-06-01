using System;
using System.Collections.Generic;
using System.Text;

namespace InventorySystem.Application.DTOs;

// We use 'record' for immutability. These act as data containers.

// DTO to send product data to the frontend (notice we send CategoryName, not the whole Category object)
public record ProductDtos(
    int Id,
    string Name,
    string Barcode,
    decimal Price,
    int Stock,
    string CategoryName,
    string SupplierName
);

// DTO to receive data from the frontend when creating a new product
public record CreateProductDto(
    string Name,
    string Barcode,
    decimal Price,
    int CategoryId,
    int SupplierId
);

// DTO to receive data when updating an existing product
public record UpdateProductDto(
    int Id,
    string Name,
    string Barcode,
    decimal Price,
    int CategoryId,
    int SupplierId
);