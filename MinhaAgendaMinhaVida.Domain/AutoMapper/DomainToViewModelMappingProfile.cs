using AutoMapper;
using MinhaAgendaMinhaVida.Domain.Model;
using MinhaAgendaMinhaVida.Domain.ViewModel;

namespace MinhaAgendaMinhaVida.Domain.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Agenda, AgendaViewModel>();
        }
    }
}