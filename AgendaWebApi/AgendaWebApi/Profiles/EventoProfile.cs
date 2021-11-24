using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgendaWebApi.Data.Dtos;
using AgendaWebApi.Models;

namespace AgendaWebApi.Profiles
{
    public class EventoProfile : Profile
    {
        //Criando perfis de conversão para o AutoMapper
        public EventoProfile() 
        {
            CreateMap<CreateEventoDto, Evento>();
            CreateMap<Evento, ReadEvento>();
            CreateMap<UpdateEventoDto, Evento>();
        }

    }
}
