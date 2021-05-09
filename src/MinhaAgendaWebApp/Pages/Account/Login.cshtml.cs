using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MinhaAgendaWebApp.Interfaces;
using MinhaAgendaWebApp.Services;
using MinhaAgendaWebApp.ViewModels;
using Refit;

namespace MinhaAgendaWebApp.Pages.Account
{
    public class LoginModel : PageModel
    {
        private readonly IAutenticacaoClient _autenticacaoClient;

        private readonly IAgendaClient _agendaClient;

        private readonly RealizarLoginService _realizarLoginService;


        public LoginModel(IAutenticacaoClient autenticacaoClient, IAgendaClient agendaClient,
            RealizarLoginService realizarLoginService)
        {
            _autenticacaoClient = autenticacaoClient;
            _agendaClient = agendaClient;
            _realizarLoginService = realizarLoginService;
        }
        [BindProperty]
        public UsuarioLogin Login { get; set; }
        public void OnGet()
        {

        }
        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                var Reposta = await _autenticacaoClient.Login(Login);

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
