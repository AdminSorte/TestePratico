using MinhaAgendaWebApp.ViewModels;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhaAgendaWebApp.Interfaces
{
    public interface IAutenticacaoClient
    {

        [Post("/api/Auth/nova-conta")]
        Task<UsuarioRespostaLogin> Login(UsuarioLogin usuarioLogin);
        [Post("/api/Auth/entrar")]
        Task<UsuarioRespostaLogin> Registro(UsuarioRegistro usuarioRegistro);
    }
}
