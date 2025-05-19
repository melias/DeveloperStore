using MediatR;
using Microsoft.AspNetCore.Mvc;
using SalesApi.Application;
using SalesApi.Application.DTOs;
using SalesApi.Application.Products;

namespace SalesApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProductsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var result = await _mediator.Send(new GetProductsQuery());
        return Ok(new ProductResponse
        {
            Data = result?.ToList(),
            Status = "sucesso",
            Message = "Operação concluída com sucesso"
        });
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] ProductRequestDto dto)
    {
        var result = await _mediator.Send(new CreateProductCommand(dto));
        return CreatedAtAction(nameof(Get), new { id = result.Id }, new ProductResponse
        {
            Data = [result],
            Status = "sucesso",
            Message = "Operação concluída com sucesso"
        });
    }
}
