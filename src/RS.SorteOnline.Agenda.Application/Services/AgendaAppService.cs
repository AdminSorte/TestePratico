using System;
using System.Collections.Generic;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using RS.SorteOnline.Agenda.Application.Interfaces;
using RS.SorteOnline.Agenda.Application.ViewModels;
using RS.SorteOnline.Agenda.Domain.Interfaces;

namespace RS.SorteOnline.Agenda.Application.Services
{
    public class AgendaAppService : IAgendaAppService
    {
        private readonly IMapper _mapper;
        private readonly IAgendaRepository _agendaRepository;

        public AgendaAppService(IMapper mapper,
                                  IAgendaRepository agendaRepository)
        {
            _mapper = mapper;
            _agendaRepository = agendaRepository;
        }

        public IEnumerable<AgendaViewModel> GetAll()
        {
            return _agendaRepository.GetAll().ProjectTo<AgendaViewModel>(_mapper.ConfigurationProvider);
        }

        public AgendaViewModel GetById(int id)
        {
            return _mapper.Map<AgendaViewModel>(_agendaRepository.GetById(id));
        }

        public void Register(AgendaViewModel agendaViewModel)
        {
            //var registerCommand = _mapper.Map<RegisterAgendaCommand>(agendaViewModel);
            //Bus.SendCommand(registerCommand);
        }

        public void Update(AgendaViewModel agendaViewModel)
        {
            //var updateCommand = _mapper.Map<UpdateAgendaCommand>(agendaViewModel);
            //Bus.SendCommand(updateCommand);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }
    }
}
