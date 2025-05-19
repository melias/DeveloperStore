using MediatR;
using Microsoft.AspNetCore.Mvc;
using SalesApi.Application;
using SalesApi.Application.DTOs;
using SalesApi.Application.Sales;

namespace SalesApi.Controllers;

[ApiController]
[Route("sales")]
public class SalesController : ControllerBase
{
    private readonly IMediator _mediator;

    public SalesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] SaleRequestDto dto)
    {
        try
        {
            var result = await _mediator.Send(new CreateSaleCommand(dto));
            return Ok(new
            {
                data = result,
                status = "success",
                message = "Sell success created"
            });
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(new SalesResponse
            {
                Data = null,
                Status = "fail",
                Message = "Error to create a sale: You can buy only 20 pices of a item."
            });
        }
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var result = await _mediator.Send(new GetSalesQuery());
        return Ok(new SalesResponse
        {
            Data = result?.ToList(),
            Status = "success",
            Message = "Operation completed successfully"
        });
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _mediator.Send(new CancelSaleCommand(id));
        return Ok(new SalesResponse
        {
            Data = null,
            Status = "success",
            Message = "Sell Cancelled"
        });
    }
}
