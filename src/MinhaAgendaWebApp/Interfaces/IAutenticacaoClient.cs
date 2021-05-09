using MinhaAgendaWebApp.ViewModels;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MinhaAgendaWebApp.Interfaces
{
    public interface IAutenticacaoClient
    {

        [Post("/api/Auth/Registre")]
        Task<UsuarioRespostaLogin> Registro(UsuarioRegistro usuarioRegistro);

        [Post("/api/Auth/entrar")]
        Task<UsuarioRespostaLogin> Login(UsuarioLogin usuarioLogin);
    }
}
