using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestePratico.Models;

namespace MinhaAgendaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgendaController : ControllerBase
    {
        private readonly DataContext _context;

        public AgendaController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Agenda
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AgendaModel>>> GetAgendaModels()
        {
            return await _context.AgendaModels.ToListAsync();
        }

        // GET: api/Agenda/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AgendaModel>> GetAgendaModel(int id)
        {
            var agendaModel = await _context.AgendaModels.FindAsync(id);

            if (agendaModel == null)
            {
                return NotFound();
            }

            return agendaModel;
        }

        // PUT: api/Agenda/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAgendaModel(int id, AgendaModel agendaModel)
        {
            if (id != agendaModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(agendaModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AgendaModelExists(id))
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

        // POST: api/Agenda
        [HttpPost]
        public async Task<ActionResult<AgendaModel>> PostAgendaModel(AgendaModel agendaModel)
        {
            _context.AgendaModels.Add(agendaModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAgendaModel", new { id = agendaModel.Id }, agendaModel);
        }

        // DELETE: api/Agenda/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAgendaModel(int id)
        {
            var agendaModel = await _context.AgendaModels.FindAsync(id);
            if (agendaModel == null)
            {
                return NotFound();
            }

            _context.AgendaModels.Remove(agendaModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AgendaModelExists(int id)
        {
            return _context.AgendaModels.Any(e => e.Id == id);
        }
    }
}
