﻿using Microsoft.AspNetCore.Mvc;
using MinhaAgenda.API.ViewModel;
using MinhaAgenda.Domain.Interfaces;
using MinhaAgenda.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhaAgenda.API.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class AgendasController : ControllerBase
    {
        private readonly IAgendaRepository _AgendaRepository;
        public AgendasController(IAgendaRepository agendaRepository)
        {
            _AgendaRepository = agendaRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Agenda>>> Index()
        {
            return Ok(await _AgendaRepository.ObterTodos());
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<List<Agenda>>> ObterPorId(int id)
        {
            return Ok(await _AgendaRepository.ObterPorId(id));
        }


        [HttpPost]
        public async Task<IActionResult> Adicionar(ViewModelAgenda viewModelAgenda)
        {

            var agenda = new Agenda(viewModelAgenda.Descricao, viewModelAgenda.Descricao, viewModelAgenda.DataAgedamento);

            var id = await _AgendaRepository.Adicionar(agenda);

            return CreatedAtAction(nameof(ObterPorId), new { id = id }, viewModelAgenda);
        }

        [HttpPut]
        public async Task<IActionResult> Atualizar(ViewModelAgenda viewModelAgenda, int id)
        {
            if (id != viewModelAgenda.Id)
            {
                return BadRequest("O id informado não e o mesmo que foi passado");
            }


            if (!await _AgendaRepository.Existe(id)) return NotFound();

            var agenda = new Agenda(viewModelAgenda.Descricao, viewModelAgenda.Descricao, viewModelAgenda.DataAgedamento);

            await _AgendaRepository.Atualizar(agenda);

            return NoContent();
        }


        [HttpDelete]
        public async Task<IActionResult> Remover(int id)
        {

            if (!await _AgendaRepository.Existe(id)) return NotFound();

            await _AgendaRepository.Remover(id);

            return NoContent();
        }
    }
}
