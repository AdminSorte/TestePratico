using AutoMapper;
using Domain.Entities;
using Infrastructure.Interfaces;
using Services.DTO;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class AgendaServico : IAgendaServico
    {
        private readonly IMapper _mapper;
        private readonly IAgendaRepositorio _agendaRepositorio;

        public AgendaServico(IMapper mapper, IAgendaRepositorio agendaRepositorio)
        {
            _mapper = mapper;
            _agendaRepositorio = agendaRepositorio;
        }

        public async Task<AgendaDTO> Criar(AgendaDTO agendaDTO)
        {
            var agendaExistente = await _agendaRepositorio.ObterTitulo(agendaDTO.Titulo);

            if (agendaExistente != null)
                throw new Exception("Já existe a agenda cadastrada com a descrição curta informada"); // Alterar quando tiver exceptions personalizadas

            var agenda = _mapper.Map<Agenda>(agendaDTO);
            agenda.Validar();

            var agendaCriada = await _agendaRepositorio.Criar(agenda);

            return _mapper.Map<AgendaDTO>(agendaCriada);

        }
        public async Task<AgendaDTO> Atualizar(AgendaDTO agendaDTO)
        {
            var agendaExistente = await _agendaRepositorio.ObterTitulo(agendaDTO.Titulo);

            if (agendaExistente != null)
                throw new Exception("Já existe a agenda cadastrada com a descrição curta informada"); // Alterar quando tiver exceptions personalizadas

            var agenda = _mapper.Map<Agenda>(agendaDTO);
            agenda.Validar();

            var agendaCriada = await _agendaRepositorio.Atualizar(agenda);

            return _mapper.Map<AgendaDTO>(agendaCriada);
        }

       
        public async Task<AgendaDTO> Obter(long id)
        {
            var agenda = await _agendaRepositorio.Obter(id);

            return _mapper.Map<AgendaDTO>(agenda);
        }

        public async Task<List<AgendaDTO>> Obter()
        {
            var todasAgendas = await _agendaRepositorio.Obter();

            return _mapper.Map<List<AgendaDTO>>(todasAgendas);
        }

        public async Task<List<AgendaDTO>> ObterTitulo(string titulo)
        {
            var agendaTitulo = await _agendaRepositorio.ObterTitulo(titulo);

            return _mapper.Map<List<AgendaDTO>>(agendaTitulo);
        }

        public async Task Remove(long id)
        {
            var agendaExistente = await _agendaRepositorio.Obter(id);

            if (agendaExistente != null)
                await _agendaRepositorio.Remover(id);
            else
                throw new Exception("Agenda não Encontrada");
        }
    }
}
