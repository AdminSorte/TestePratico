using AutoMapper;
using MinhaAgendaMinhaVida.Domain.Commands.Agenda;
using MinhaAgendaMinhaVida.Domain.Model;

namespace MinhaAgendaMinhaVida.Domain.AutoMapper
{
    public class CommandToDomainMappingProfile : Profile
    {
        public CommandToDomainMappingProfile()
        {
            CreateMap<InsertAgendaCommand, Agenda>();
            CreateMap<UpdateAgendaCommand, Agenda>();
        }
    }
}