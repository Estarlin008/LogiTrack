using Microsoft.AspNetCore.Mvc;
using LogiTrack.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.EntityFrameworkCore;
namespace LogiTrack.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class InventoryController : ControllerBase
    {
        private readonly LogiTrackContext _context;
        private readonly IMemoryCache _cache;
        public InventoryController(LogiTrackContext context, IMemoryCache cache)
        {
            _context = context;
            _cache = cache;
        }

        // GET: /api/inventory
        [HttpGet]
        public async Task<IActionResult> GetInventory()
        {
            const string cacheKey = "inventory_items";

            var items = await _cache.GetOrCreateAsync(cacheKey, async entry =>
            {
                entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(10);
                entry.SlidingExpiration = TimeSpan.FromMinutes(5);

                return await _context.InventoryItems
                    .AsNoTracking()
                    .ToListAsync();
            });
            
            return Ok(items);
        }

        // POST: /api/inventory
        [HttpPost]
        public async Task<IActionResult> AddInventoryItem([FromBody] InventoryItem item)
        {
            _context.InventoryItems.Add(item);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetInventory), new { id = item.ItemId }, item);
        }

        // DELETE: /api/inventory/{id}
        [Authorize(Roles = "Manager")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInventoryItem(int id)
        {
            var item = _context.InventoryItems.Find(id);

            if (item == null)
            {
                return NotFound();
            }

            _context.InventoryItems.Remove(item);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}