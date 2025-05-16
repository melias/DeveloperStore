using Microsoft.AspNetCore.Mvc;
using SalesApi.Application.DTOs;
using SalesApi.Application.Services;

namespace SalesApi.Controllers;

[ApiController]
[Route("sales")]
public class SalesController : ControllerBase
{
    private readonly ISaleService _service;

    public SalesController(ISaleService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] SaleRequestDto dto)
    {
        try
        {
            var result = await _service.CreateAsync(dto);
            return Ok(new
            {
                data = result,
                status = "success",
                message = "Sell success created"
            });
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(new
            {
                type = "BadRequest",
                error = "Invalid Sell",
                detail = ex.Message
            });
        }
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var result = await _service.GetAllAsync();
        return Ok(new
        {
            data = result,
            status = "success",
            message = "Operation completed successfully"
        });
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _service.CancelAsync(id);
        return Ok(new
        {
            status = "success",
            message = "Sell Cancelled"
        });
    }
}
