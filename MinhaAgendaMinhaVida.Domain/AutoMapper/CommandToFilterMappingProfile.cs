using AutoMapper;
using MinhaAgendaMinhaVida.Domain.Commands.Agenda;
using MinhaAgendaMinhaVida.Domain.Filter;

namespace MinhaAgendaMinhaVida.Domain.AutoMapper
{
    public class CommandToFilterMappingProfile : Profile
    {
        public CommandToFilterMappingProfile()
        {
            CreateMap<SelectAgendaCommand, SelectAgendaFilter>();
        }
    }
}