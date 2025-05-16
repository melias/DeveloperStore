using Microsoft.AspNetCore.Mvc;
using SalesApi.Application.DTOs;
using SalesApi.Application.Services;

namespace SalesApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IProductService _service;

    public ProductsController(IProductService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var result = await _service.GetAllAsync();
        return Ok(new
        {
            dados = result,
            status = "sucesso",
            mensagem = "Operação concluída com sucesso"
        });
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] ProductRequestDto dto)
    {
        var result = await _service.CreateAsync(dto);
        return CreatedAtAction(nameof(Get), new { id = result.Id }, new
        {
            dados = result,
            status = "sucesso",
            mensagem = "Operação concluída com sucesso"
        });
    }
}
