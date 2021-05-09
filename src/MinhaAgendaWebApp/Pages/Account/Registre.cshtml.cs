using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MinhaAgendaWebApp.Interfaces;
using MinhaAgendaWebApp.Services;
using MinhaAgendaWebApp.ViewModels;
using Refit;

namespace MinhaAgendaWebApp.Pages.Account
{
    public class RegistreModel : PageModel
    {
        public UsuarioRegistro usuarioRegistro { get; set; }

        private readonly IAutenticacaoClient _autenticacaoClient;
        private readonly RealizarLoginService _realizarLoginService;


        public UsuarioRegistro UsuarioRegistro { get; set; }
        public RegistreModel(IAutenticacaoClient autenticacaoClient,
            RealizarLoginService realizarLoginService)
        {
            _autenticacaoClient = autenticacaoClient;
            _realizarLoginService = realizarLoginService;
        }
        public void OnGet()
        {

        }

        public async Task<ActionResult> OnPostAsync(UsuarioRegistro usuarioRegistro)
        {

            try
            {
                var Reposta = await _autenticacaoClient.Registro(usuarioRegistro);

                await _realizarLoginService.RealizarLogin(Reposta, HttpContext);
            }
            catch (ApiException ex)
            {

                TempData["error"] = ex.Content;
                return Page();
            }
            return RedirectToPage("/Agenda/Index");
        }


    }
}
