using Microsoft.AspNetCore.Mvc;
using LogiTrack.Models;

namespace LogiTrack.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InventoryController : ControllerBase
    {private readonly LogiTrackContext _context;

        public InventoryController(LogiTrackContext context)
        {
            _context = context;
        }

        // GET: /api/inventory
        [HttpGet]
        public IActionResult GetInventory()
        {
            var items = _context.InventoryItems.ToList();
            return Ok(items);
        }

        // POST: /api/inventory
        [HttpPost]
        public IActionResult AddInventoryItem([FromBody] InventoryItem item)
        {
            _context.InventoryItems.Add(item);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetInventory), new { id = item.ItemId }, item);
        }

        // DELETE: /api/inventory/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteInventoryItem(int id)
        {
            var item = _context.InventoryItems.Find(id);

            if (item == null)
            {
                return NotFound();
            }

            _context.InventoryItems.Remove(item);
            _context.SaveChanges();

            return NoContent();
        }
    }
}