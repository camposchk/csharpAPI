using System;
using System.Threading.Tasks;
using csharpAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace csharpAPI.Controllers;

[ApiController]
[Route("order")]
public class OrderController : ControllerBase
{

    [HttpPost("create/{storeId}")]
    public async Task<ActionResult> CreateOrder(int storeId, 
        [FromServices]IOrderRepository repo)
    {
        try 
        {
            var orderId = await repo.CreateOrder(storeId);
            return Ok(orderId);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}