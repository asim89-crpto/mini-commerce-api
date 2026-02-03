using Microsoft.AspNetCore.Mvc;
using MiniCommerce.Api.Dtos;
using MiniCommerce.Api.Services;

namespace MiniCommerce.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IProductService _service;

    public ProductsController(IProductService service) => _service = service;

    [HttpGet]
    public IActionResult GetAll() => Ok(_service.GetAll());

    [HttpGet("{id:guid}")]
    public IActionResult GetById(Guid id)
    {
        var p = _service.GetById(id);
        return p is null ? NotFound() : Ok(p);
    }

    [HttpPost]
    public IActionResult Create([FromBody] CreateProductDto dto)
    {
        var created = _service.Create(dto);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpPut("{id:guid}")]
    public IActionResult Update(Guid id, [FromBody] UpdateProductDto dto)
    {
        var ok = _service.Update(id, dto);
        return ok ? NoContent() : NotFound();
    }

    [HttpDelete("{id:guid}")]
    public IActionResult Delete(Guid id)
    {
        var ok = _service.Delete(id);
        return ok ? NoContent() : NotFound();
    }
}
