using System.Net.Http.Headers;
using Microsoft.AspNetCore.Mvc;
using WebApi.services;
using WebApi.services.Dots;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WarehouseController : ControllerBase
{
    private readonly IWarehouseService _warehouseService;

    public WarehouseController(IWarehouseService warehouseService)
    {
        _warehouseService = warehouseService;
    }

    [HttpPost]
    public async Task<IActionResult> Post(WarehouseDto model)
    {
        var result = await _warehouseService.Add(model);
        if (!result.IsSuccessFull)
        {
            return BadRequest(result);
        }
        return Ok(result);
    }
}