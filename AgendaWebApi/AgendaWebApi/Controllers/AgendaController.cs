using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgendaWebApi.Models;
using AgendaWebApi.Data;
using AgendaWebApi.Data.Dtos;
using AutoMapper;

namespace AgendaWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AgendaController : ControllerBase
    {
        private AgendaContext _context;
        private IMapper _mapper;

        public AgendaController(AgendaContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }




        [HttpPost]
        public IActionResult AdicionarEvento([FromBody] CreateEventoDto novoEvento)
        {
            Evento evento = _mapper.Map<Evento>(novoEvento);

            _context.Eventos.Add(evento);
            _context.SaveChanges();

            return CreatedAtAction(nameof(PesquisaDescricaoEvento), new { descricao = evento.Descricao }, evento);
        }

        [HttpGet]
        public IEnumerable<Evento> RecuperaEvento()
        {

            return _context.Eventos;
        }



        [HttpGet("{descricao}")]
        public IActionResult PesquisaDescricaoEvento(string descricao)
        {
            Evento evento = _context.Eventos.FirstOrDefault(evento => evento.Descricao == descricao);
            if (evento != null)
            {
                ReadEvento ltsEvento = _mapper.Map<ReadEvento>(evento);
                return Ok(ltsEvento);
            }
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaEvento(int id, [FromBody] UpdateEventoDto eventoatualizado)
        {

            Evento evento = _context.Eventos.FirstOrDefault(evento => evento.Id == id);

            if(evento == null)
            {
                return NotFound();

            }


            //Sobreescreve as informações da entidade eventos para entidade eventoatualizado
            _mapper.Map(eventoatualizado, evento);

            evento.Descricao = eventoatualizado.Descricao;
            evento.Data = eventoatualizado.Data;
            evento.Periodo = eventoatualizado.Periodo;
            _context.SaveChanges();
            return NoContent();
            



        }

        [HttpDelete("{id}")]
        public IActionResult DeletaEvento(int id)
        {
            Evento evento = _context.Eventos.FirstOrDefault(evento => evento.Id == id);

            if (evento == null)
            {
                return NotFound();

            }
            _context.Remove(evento);
            _context.SaveChanges();
            return NoContent();

        }

    }
}
