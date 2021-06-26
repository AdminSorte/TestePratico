﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MinhaAgendaMinhaVida.Domain.Commands.Agenda;
using MinhaAgendaMinhaVida.Domain.Filter;
using MinhaAgendaMinhaVida.Domain.Interfaces.Infra;
using MinhaAgendaMinhaVida.Domain.Interfaces.Service;
using MinhaAgendaMinhaVida.Domain.ViewModel;

namespace MinhaAgendaMinhaVida.Service.Services
{
    public class AgendaService : BaseService, IAgendaService
    {
        private readonly IMapper _mapper;
        private readonly IAgendaRepository _agendaRepository;

        public AgendaService(
            IMapper mapper,
            IAgendaRepository agendaRepository)
        {
            _mapper = mapper;
            _agendaRepository = agendaRepository;
        }

        public IEnumerable<AgendaViewModel> List(SelectAgendaCommand command)
        {
            var filter = _mapper.Map<SelectAgendaFilter>(command);
            var model = _agendaRepository.List(filter);
            var viewModel = _mapper.Map<IEnumerable<AgendaViewModel>>(model);
            return viewModel;
        }
    }
}
