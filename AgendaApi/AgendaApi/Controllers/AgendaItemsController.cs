using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AgendaApi.Models;

namespace AgendaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgendaItemsController : ControllerBase
    {
        private readonly AgendaContext _context;

        public AgendaItemsController(AgendaContext context)
        {
            _context = context;
        }

        // GET: api/AgendaItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AgendaItemDTO>>> GetAgendaItems()
        {
            return await _context.AgendaItems
                .Select(x => ItemToDTO(x))
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AgendaItemDTO>> GetAgendaItem(long id)
        {
            var agendaItem = await _context.AgendaItems.FindAsync(id);

            if (agendaItem == null)
            {
                return NotFound();
            }

            return ItemToDTO(agendaItem);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAgendaItem(long id, AgendaItemDTO agendaItemDTO)
        {
            if (id != agendaItemDTO.Id)
            {
                return BadRequest();
            }

            var agendaItem = await _context.AgendaItems.FindAsync(id);
            if (agendaItem == null)
            {
                return NotFound();
            }

            agendaItem.Name = agendaItemDTO.Name;
            agendaItem.IsComplete = agendaItemDTO.IsComplete;
            agendaItem.Description = agendaItemDTO.Description;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) when (!AgendaItemExists(id))
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<AgendaItemDTO>> CreateAgendaItem(AgendaItemDTO agendaItemDTO)
        {
            var agendaItem = new AgendaItem
            {
                IsComplete = agendaItemDTO.IsComplete,
                Name = agendaItemDTO.Name,
                Description = agendaItemDTO.Description,
            };

            _context.AgendaItems.Add(agendaItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetAgendaItem),
                new { id = agendaItem.Id },
                ItemToDTO(agendaItem));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAgendaItem(long id)
        {
            var agendaItem = await _context.AgendaItems.FindAsync(id);

            if (agendaItem == null)
            {
                return NotFound();
            }

            _context.AgendaItems.Remove(agendaItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AgendaItemExists(long id) =>
             _context.AgendaItems.Any(e => e.Id == id);

        private static AgendaItemDTO ItemToDTO(AgendaItem agendaItem) =>
            new AgendaItemDTO
            {
                Id = agendaItem.Id,
                Name = agendaItem.Name,
                IsComplete = agendaItem.IsComplete,
                Description = agendaItem.Description
            };
    }
}
