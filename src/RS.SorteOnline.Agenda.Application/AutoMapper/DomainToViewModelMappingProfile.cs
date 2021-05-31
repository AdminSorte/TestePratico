using AutoMapper;
using RS.SorteOnline.Agenda.Application.ViewModels;
using RS.SorteOnline.Agenda.Domain.Models;

namespace RS.SorteOnline.Agenda.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<AgendaModel, AgendaViewModel>();
        }
    }
}
