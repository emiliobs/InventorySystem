using InventorySystem.Application.DTOs;
using InventorySystem.Domain.Entities;
using InventorySystem.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace InventorySystem.Application.Services;

public class ProductService : IProductService
{
    private readonly IUnitOfWork _unitOfWork;

    public ProductService(IUnitOfWork unitOfWork)
    {
        this._unitOfWork = unitOfWork;
    }

    // GET ALl
    public async Task<ApiResponse<IEnumerable<ProductDtos>>> GetAllProductsAsync()
    {
        try
        {
            // Fetch all products from the database
            var products = await _unitOfWork.Products.GetAllAsync();

            // Map the products to DTOs
            var productsDtos = products.Select(p => new ProductDtos(
                    p.Id,
                    p.Name,
                    p.Barcode,
                    p.Price,
                    p.Stock,
                    p.Category?.Name ?? "N/A",
                    p.Supplier?.CompanyName ?? "N/A"
                ));

            return ApiResponse<IEnumerable<ProductDtos>>.SuccessResponse(productsDtos, "Products retrieved successfully.");
        }
        catch (Exception ex)
        {
            return ApiResponse<IEnumerable<ProductDtos>>.ErrorResponse($"Error retrieving products: {ex.Message}");
        }
    }

    // GET BY ID
    public async Task<ApiResponse<ProductDtos>> GetProductByIdAsync(int id)
    {
        try
        {
            var product = await _unitOfWork.Products.GetByIdAsync(id);

            if (product is null)
            {
                return ApiResponse<ProductDtos>.ErrorResponse($"Product with id {id} not found.");
            }

            var productDto = new ProductDtos(
                    product.Id,
                    product.Name,
                    product.Barcode,
                    product.Price,
                    product.Stock,
                    product.Category?.Name ?? "N/A",
                    product.Supplier?.CompanyName ?? "N/A"
                );

            return ApiResponse<ProductDtos>.SuccessResponse(productDto);
        }
        catch (Exception ex)
        {
            return ApiResponse<ProductDtos>.ErrorResponse($"Error retrieving product: {ex.Message}");
        }
    }

    // CREATE
    public async Task<ApiResponse<ProductDtos>> CreateProductAsync(CreateProductDto dto)
    {
        try
        {
            var product = new Product
            {
                Name = dto.Name,
                Barcode = dto.Barcode,
                Price = dto.Price,
                Stock = 0,
                CategoryId = dto.CategoryId,
                SupplierId = dto.SupplierId,
                CreatedAt = DateTime.UtcNow,
                IsActive = true,
            };

            await _unitOfWork.Products.AddAsync(product);
            await _unitOfWork.SaveChnagesAsync();

            var resultDto = new ProductDtos(

                 product.Id,
                 product.Name,
                 product.Barcode,
                 product.Price,
                 product.Stock,
                 "N/A",
                 "N/A"
                );

            return ApiResponse<ProductDtos>.SuccessResponse(resultDto, "Product created successfully!");
        }
        catch (Exception ex)
        {
            return ApiResponse<ProductDtos>.ErrorResponse($"Error creating product: {ex.Message}");
        }
    }

    // Update
    public async Task<ApiResponse<bool>> UpdateProductAsync(UpdateProductDto dto)
    {
        try
        {
            var product = await _unitOfWork.Products.GetByIdAsync(dto.Id);

            if (product is null)
            {
                return ApiResponse<bool>.ErrorResponse($"Product with id {dto.Id} not found.");
            }

            product.Name = dto.Name;
            product.Barcode = dto.Barcode;
            product.Price = dto.Price;
            product.CategoryId = dto.CategoryId;
            product.SupplierId = dto.SupplierId;
            product.UpdateAt = DateTime.UtcNow;

            _unitOfWork.Products.Update(product);
            await _unitOfWork.SaveChnagesAsync();

            return ApiResponse<bool>.SuccessResponse(true, "Product update successfully!");
        }
        catch (Exception ex)
        {
            return ApiResponse<bool>.ErrorResponse($"Error updating product: {ex.Message}");
        }
    }

    // Delete
    public async Task<ApiResponse<bool>> DeleteProductAsync(int id)
    {
        try
        {
            var product = await _unitOfWork.Products.GetByIdAsync(id);

            if (product is null)
            {
                return ApiResponse<bool>.ErrorResponse($"Product with id: {id} not found.");
            }

            _unitOfWork.Products.Delete(product);
            await _unitOfWork.SaveChnagesAsync();

            return ApiResponse<bool>.SuccessResponse(true, "Product deleted successfully!");
        }
        catch (Exception ex)
        {
            return ApiResponse<bool>.ErrorResponse($"Error deleting product: {ex.Message}");
        }
    }
}