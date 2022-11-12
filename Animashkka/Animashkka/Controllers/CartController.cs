using Animashkka.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Animashkka.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CartController : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<Cart>> PostCart(Cart cart)
        {
            var context = new AnimalContext();
            context.Carts.Add(cart);
            await context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetCart), new { id = cart.Id }, cart);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Cart>> GetCart(int id)
        {
            var context = new AnimalContext();
            var cart = await context.Carts.FindAsync(id);
            if (cart == null)
            {
                return NotFound();
            }
            return cart;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cart>>> GetCarts()
        {
            var context = new AnimalContext();
            return await context.Carts.ToListAsync();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCart(int id, Cart cart)
        {
            if (id != cart.Id)
            {
                return BadRequest();
            }
            var context = new AnimalContext();
            context.Entry(cart).State = EntityState.Modified;
            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CartExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return NoContent();
        }

        private bool CartExists(int id)
        {
            return new AnimalContext().Carts.Any(e => e.Id == id);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCart(int id)
        {
            var context = new AnimalContext();
            var cart = await context.Carts.FindAsync(id);
            if (cart == null)
            {
                return NotFound();
            }
            context.Carts.Remove(cart);
            await context.SaveChangesAsync();
            return NoContent();
        }
        
    }
}
