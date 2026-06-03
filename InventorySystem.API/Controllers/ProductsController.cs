using InventorySystem.Application.DTOs;
using InventorySystem.Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventorySystem.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductsController(IProductService productService)
    {
        this._productService = productService;
    }

    // GET: api/Products
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _productService.GetAllProductsAsync();

        return result.Success ? Ok(result) : BadRequest(result);
    }

    // GET: api/Products/5
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _productService.GetProductByIdAsync(id);

        return result.Success ? Ok(result) : BadRequest(result);
    }

    // POST: api/Products
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateProductDto productDto)
    {
        var result = await _productService.CreateProductAsync(productDto);

        return result.Success ? Ok(result) : BadRequest(result);
    }

    // PUT: api/Products
    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateProductDto productDto)
    {
        var result = await _productService.UpdateProductAsync(productDto);

        return result.Success ? Ok(result) : NotFound(result);
    }

    // DELETE: api/Products/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _productService.DeleteProductAsync(id);

        return result.Success ? Ok(result) : NotFound(result);
    }
}