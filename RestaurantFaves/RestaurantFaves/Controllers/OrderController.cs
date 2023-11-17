using Microsoft.AspNetCore.Mvc;
using RestaurantFaves.Models.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using RestaurantFaves.Models;
using Microsoft.Extensions.FileProviders;

namespace RestaurantFaves.Controllers;

public class OrderController : Controller
{
    private readonly AppDbContext _appDbContext;

    public OrderController(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    [HttpGet("GetOrders")]
    public async Task<IActionResult> GetOrders()
    {
        return Ok(await _appDbContext.Orders.ToListAsync());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetOrderById(int id)
    {
        var order = await _appDbContext.Orders.FirstOrDefaultAsync(x => x.id == id);

        if(order == null)
        {
            return NotFound();
        }

        return Ok(order);
    }
    [HttpPost("AddOrder")]
    public async Task<IActionResult> AddOrder([FromBody] Order order)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        _appDbContext.Orders.Add(order);

        await _appDbContext.SaveChangesAsync();

        return Ok(order);
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateOrder([FromBody] Order order, int id)
    {
        var dbOrder = await _appDbContext.Orders.FirstOrDefaultAsync(x => x.id == id);

        if (dbOrder == null)
        {
            return NotFound();
        }

        dbOrder.description = order.description;
        dbOrder.restaurant = order.restaurant;
        dbOrder.rating = order.rating;
        dbOrder.orderAgain = order.orderAgain;
        
        await _appDbContext.SaveChangesAsync();

        return Ok(dbOrder);
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteOrder(int id)
    {
        var order = await _appDbContext.Orders.FirstOrDefaultAsync(x => x.id == id);

        if (order == null)
        {
            return NotFound();
        }

        _appDbContext.Orders.Remove(order);

        await _appDbContext.SaveChangesAsync();

        return NoContent();
    }
}
