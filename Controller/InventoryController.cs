using Microsoft.AspNetCore.Mvc;
using LogiTrack.Models;
using Microsoft.AspNetCore.Authorization;
namespace LogiTrack.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class InventoryController : ControllerBase
    {
        private readonly LogiTrackContext _context;

        public InventoryController(LogiTrackContext context)
        {
            _context = context;
        }

        // GET: /api/inventory
        [HttpGet]
        public async Task<IActionResult> GetInventory()
        {
            var items = _context.InventoryItems.ToList();
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