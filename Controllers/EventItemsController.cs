using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HFT.Models;

namespace HFT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventItemsController : ControllerBase
    {
        private readonly EventContext _context;

        public EventItemsController(EventContext context)
        {
            _context = context;
        }

        // GET: api/EventItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EventItem>>> GetEvents()
        {
            return await _context.Events.ToListAsync();
        }

        // GET: api/EventItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EventItem>> GetEventItem(long id)
        {
            var eventItem = await _context.Events.FindAsync(id);

            if (eventItem == null)
            {
                return NotFound();
            }

            return eventItem;
        }

        // PUT: api/EventItems/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEventItem(long id, EventItem eventItem)
        {
            if (id != eventItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(eventItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventItemExists(id))
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

        // POST: api/EventItems
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<EventItem>> PostEventItem(EventItem eventItem)
        {
            _context.Events.Add(eventItem);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetEventItem", new { id = eventItem.Id }, eventItem);
            return CreatedAtAction(nameof(GetEventItem), new { id = eventItem.Id }, eventItem);
        }

        // DELETE: api/EventItems/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<EventItem>> DeleteEventItem(long id)
        {
            var eventItem = await _context.Events.FindAsync(id);
            if (eventItem == null)
            {
                return NotFound();
            }

            _context.Events.Remove(eventItem);
            await _context.SaveChangesAsync();

            return eventItem;
        }

        private bool EventItemExists(long id)
        {
            return _context.Events.Any(e => e.Id == id);
        }
    }
}
