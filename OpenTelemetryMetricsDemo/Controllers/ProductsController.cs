using Microsoft.AspNetCore.Mvc;

namespace MyDotNetApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    [HttpGet]
    public IActionResult GetProducts()
    {
        return Ok(new[]
        {
            new { Id = 1, Name = "Laptop" },
            new { Id = 2, Name = "Mobile" },
            new { Id = 3, Name = "Keyboard" }
        });
    }

    [HttpGet("{id}")]
    public IActionResult GetProduct(int id)
    {
        if (id <= 0)
        {
            return BadRequest(new
            {
                message = "Invalid product ID"
            });
        }

        if (id == 999)
        {
            return NotFound(new
            {
                message = "Product not found"
            });
        }

        return Ok(new
        {
            Id = id,
            Name = "Laptop"
        });
    }

    [HttpPost]
    public IActionResult CreateProduct()
    {
        return Created(
            "/api/products/100",
            new
            {
                Id = 100,
                Name = "Monitor"
            });
    }
}