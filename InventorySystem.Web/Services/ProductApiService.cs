using InventorySystem.Application.DTOs;
using System.Net.Http.Json;

namespace InventorySystem.Web.Services;

public class ProductApiService
{
    private readonly HttpClient _httpClient;

    public ProductApiService(HttpClient httpClient)
    {
        this._httpClient = httpClient;
    }

    public async Task<ApiResponse<IEnumerable<ProductDtos>>> GetProductAsync()
    {
        try
        {
            // Makes a GET request to https://localhost:5001/api/products
            var result = await _httpClient.GetFromJsonAsync<ApiResponse<IEnumerable<ProductDtos>>>("api/products");
            return result ?? ApiResponse<IEnumerable<ProductDtos>>.ErrorResponse("Empty response");
        }
        catch (Exception ex)
        {
            return ApiResponse<IEnumerable<ProductDtos>>.ErrorResponse($"Network Error: {ex.Message}");
        }
    }

    public async Task<ApiResponse<ProductDtos>> CreateProdcutAsync(CreateProductDto createProductDto)
    {
        try
        {
            // Makes a POST reuqs automatically converting the DTO int JSON and sending it to https://localhost:5001/api/products
            var response = await _httpClient.PostAsJsonAsync("api/products", createProductDto);
            var result = await response.Content.ReadFromJsonAsync<ApiResponse<ProductDtos>>();

            return result ?? ApiResponse<ProductDtos>.ErrorResponse("Error reading server response.");
        }
        catch (Exception ex)
        {
            return ApiResponse<ProductDtos>.ErrorResponse($"Network Error: {ex.Message}");
        }
    }

    public async Task<ApiResponse<bool>> UpdateProductAsync(UpdateProductDto updateProductDto)
    {
        try
        {
            var response = await _httpClient.PutAsJsonAsync("api/products", updateProductDto);
            var result = await response.Content.ReadFromJsonAsync<ApiResponse<bool>>();
            return result ?? ApiResponse<bool>.ErrorResponse("Error reading server response.");
        }
        catch (Exception ex)
        {
            return ApiResponse<bool>.ErrorResponse($"Network Error: {ex.Message}");
        }
    }

    public async Task<ApiResponse<bool>> DeleteProductAsync(int id)
    {
        try
        {
            var response = await _httpClient.DeleteAsync($"api/products/{id}");
            var result = await response.Content.ReadFromJsonAsync<ApiResponse<bool>>();
            return result ?? ApiResponse<bool>.ErrorResponse("Error reading server response.");
        }
        catch (Exception ex)
        {
            return ApiResponse<bool>.ErrorResponse($"Network Error: {ex.Message}");
        }
    }
}