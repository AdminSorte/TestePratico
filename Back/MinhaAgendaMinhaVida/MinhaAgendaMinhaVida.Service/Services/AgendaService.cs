using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MinhaAgendaMinhaVida.Domain.Commands.Agenda;
using MinhaAgendaMinhaVida.Domain.Filter;
using MinhaAgendaMinhaVida.Domain.Interfaces.Infra;
using MinhaAgendaMinhaVida.Domain.Interfaces.Service;
using MinhaAgendaMinhaVida.Domain.Model;
using MinhaAgendaMinhaVida.Domain.ViewModel;
using MinhaAgendaMinhaVida.Service.Validators.Agenda;

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

        public int Add(InsertAgendaCommand command)
        {
            Validate(command, new InsertAgendaValidator());

            var model = _mapper.Map<Agenda>(command);

            return _agendaRepository.Add(model);
        }

        public AgendaViewModel View(int id)
        {
            var model = _agendaRepository.View(id);
            return _mapper.Map<AgendaViewModel>(model);
        }

        public bool Delete(int id) => _agendaRepository.Delete(id);
    }
}
