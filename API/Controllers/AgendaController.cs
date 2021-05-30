using API.Utilities;
using API.ViewModels;
using AutoMapper;
using ExceptionsDomain.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Services.DTO;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    public class AgendaController : ControllerBase
    {
        private readonly IAgendaServico _agendaServico;
        private readonly IMapper _mapper;

        public AgendaController(IAgendaServico agendaServico, IMapper mapper)
        {
            _agendaServico = agendaServico;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("/api/v1/agenda/criar")]

        public async Task<IActionResult> Criar([FromBody] CriarAgendaViewModel agendaViewModel)
        {
            try
            {
                var agendaDTO = _mapper.Map<AgendaDTO>(agendaViewModel);
                var agendaCriada = await _agendaServico.Criar(agendaDTO);

                return Ok(new ResultadoViewModel
                {
                    Mensagem = "Agenda Criada com Sucesso!",
                    Sucesso = true,
                    Data =  agendaCriada
                });

            }
            catch (DomainExceptions ex)
            {
                return BadRequest(Respostas.ErroDominio(ex.Message, ex.Errors));
            }
            catch (Exception)
            {

                return StatusCode(500, Respostas.ErroAplicacao());
            }
        }


        [HttpPut]
        [Route("/api/v1/agenda/atualizar")]

        public async Task<IActionResult> Atualizar([FromBody] AtualizarViewModel agendaViewModel)
        {
            try
            {
                var agendaDTO = _mapper.Map<AgendaDTO>(agendaViewModel);
                var agendaCriada = await _agendaServico.Atualizar(agendaDTO, agendaDTO.Id);

                return Ok(new ResultadoViewModel
                {
                    Mensagem = "Agenda Atualizada com Sucesso!",
                    Sucesso = true,
                    Data = agendaCriada
                });

            }
            catch (DomainExceptions ex)
            {
                return BadRequest(Respostas.ErroDominio(ex.Message, ex.Errors));
            }
            catch (Exception)
            {

                return StatusCode(500, Respostas.ErroAplicacao());
            }
        }

        [HttpGet]
        [Route("/api/v1/agenda/get-agenda/{id}")]

        public async Task<IActionResult> Obter(long id)
        {
            try
            {
                var agenda = await _agendaServico.Obter(id);

                if (agenda == null)
                    return Ok(new ResultadoViewModel
                    {
                        Mensagem = "Nenhuma agenda encontrada com o ID Digitado",
                        Sucesso = true,
                        Data = agenda
                    });

                return Ok (new ResultadoViewModel
                {
                    Mensagem = "Agenda Encontrada",
                    Sucesso = true,
                    Data = agenda
                });

            }
            catch(DomainExceptions ex)
            {
                return BadRequest(Respostas.ErroDominio(ex.Message, ex.Errors));
            }
            catch (Exception)
            {

                return StatusCode(500, Respostas.ErroAplicacao());
            }
        }

        [HttpGet]
        [Route("/api/v1/agenda/get-all")]

        public async Task<IActionResult> Obter()
        {
            try
            {
                var todasAgendas = await _agendaServico.Obter();
                return Ok(new ResultadoViewModel
                {
                    Mensagem = "Agendas Encontradas",
                    Sucesso = true,
                    Data = todasAgendas
                }); ;
            }
            catch (DomainExceptions ex)
            {
                return BadRequest(Respostas.ErroDominio(ex.Message, ex.Errors));
            }
            catch (Exception)
            {

                return StatusCode(500, Respostas.ErroAplicacao());
            }

        }

        [HttpDelete]
        [Route("/api/v1/agenda/remove/{id}")]

        public async Task<IActionResult> Remover(long id)
        {
            try
            {
                await _agendaServico.Remove(id);

                return Ok(new ResultadoViewModel
                {
                    Mensagem = "Agenda Encontrada",
                    Sucesso = true,
                    Data = null
                });

            }
            catch (DomainExceptions ex)
            {
                return BadRequest(Respostas.ErroDominio(ex.Message, ex.Errors));
            }
            catch (Exception)
            {

                return StatusCode(500, Respostas.ErroAplicacao());
            }
        }
    }
}
