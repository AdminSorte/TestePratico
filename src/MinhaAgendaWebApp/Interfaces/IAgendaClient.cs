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
        Task<List<ViewModelAgenda>> ObterTodos();

        [Get("/api/Agendas/{Titulo}")]
        Task<List<ViewModelAgenda>> ObterPorTitulo(string Titulo);

        [Get("/api/Agendas/{Id}")]
        Task<ViewModelAgenda> ObterPorId(int Id);

        [Post("/api/Agendas")]
        Task<ViewModelAgenda> Adicionar(ViewModelAgenda agenda);

        [Put("/api/Agendas")]
        Task<ViewModelAgenda> Atualizar(ViewModelAgenda agenda);
    }
}
