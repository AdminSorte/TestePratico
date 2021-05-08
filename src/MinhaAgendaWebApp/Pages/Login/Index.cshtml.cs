using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MinhaAgendaWebApp.Interfaces;
using MinhaAgendaWebApp.ViewModels;

namespace MinhaAgendaWebApp.Pages.Login
{
    public class IndexModel : PageModel
    {
        private readonly IAutenticacaoClient _autenticacaoClient;

        public IndexModel(IAutenticacaoClient autenticacaoClient)
        {
            _autenticacaoClient = autenticacaoClient;
        }
        public UsuarioLogin login { get; set; }
        public void OnGet()
        {

        }
        public async Task OnPostAsync(UsuarioLogin usuarioLogin)
        {

            var teste = new UsuarioLogin();
            teste.Email = "user@example1.com";
            teste.Senha = "string@!12S";

             await  _autenticacaoClient.Login(teste);


  
        }
    }
}
