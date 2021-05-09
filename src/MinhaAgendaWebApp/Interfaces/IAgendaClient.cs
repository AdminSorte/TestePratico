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
        Task<List<AgendaViewModel>> ObterTodos(
             [Header("Authorization")] string token);

        [Get("/api/Agendas/{Titulo}")]
        Task<List<AgendaViewModel>> ObterPorTitulo(string Titulo,
             [Header("Authorization")] string token);

        [Get("/api/Agendas/{Id}")]
        Task<AgendaViewModel> ObterPorId(int Id,
             [Header("Authorization")] string token);

        [Post("/api/Agendas")]
        Task<AgendaViewModel> Adicionar(AgendaViewModel agenda,
             [Header("Authorization")] string token);

        [Put("/api/Agendas")]
        Task Atualizar(AgendaViewModel agenda,int id,
             [Header("Authorization")] string token);
    }
}
