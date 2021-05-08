using MinhaAgendaWebApp.ViewModels;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhaAgendaWebApp.Interfaces
{
   public interface IAgendaClient
    {
        [Get("/api/Agendas")]
        Task<List<AgendaViewModel>> ObterTodos();

        [Get("/api/Agendas/{Titulo}")]
        Task<List<AgendaViewModel>> ObterPorTitulo(string Titulo);

        [Get("/api/Agendas/{Id}")]
        Task<AgendaViewModel> ObterPorId(int Id);

        [Post("/api/Agendas")]
        Task<AgendaViewModel> Adicionar(AgendaViewModel agenda);

        [Put("/api/Agendas")]
        Task Atualizar(AgendaViewModel agenda,int id);
    }
}
