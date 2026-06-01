using InventorySystem.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace InventorySystem.Application.Services;

public interface IProductService
{
    Task<ApiResponse<IEnumerable<ProductDtos>>> GetAllProductsAsync();

    Task<ApiResponse<ProductDtos>> GetProductByIdAsync(int id);

    Task<ApiResponse<ProductDtos>> CreateProductAsync(CreateProductDto dto);

    Task<ApiResponse<bool>> UpdateProductAsync(UpdateProductDto dto);

    Task<ApiResponse<bool>> DeleteProductAsync(int id);
}