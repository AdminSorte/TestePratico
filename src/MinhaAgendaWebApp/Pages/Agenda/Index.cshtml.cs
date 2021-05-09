using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.Extensions.Logging;
using MinhaAgendaWebApp.Interfaces;
using MinhaAgendaWebApp.Services;
using MinhaAgendaWebApp.ViewModels;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhaAgendaWebApp.Pages.Agenda
{
   
    public class IndexModel : PageModel
    {
        private readonly IAgendaClient _agendaClient;
        private readonly IRazorRenderService _renderService;
        private readonly IHttpContextAccessor _accessor;

        public string Token;

        public IndexModel( IAgendaClient agendaClient, IRazorRenderService razorRenderService, IHttpContextAccessor accessor)
        {

            _agendaClient = agendaClient;
            _renderService = razorRenderService;
            _accessor = accessor;

            if(_accessor.HttpContext.User.Identity.IsAuthenticated)
            {
                Token = "Bearer " + _accessor.HttpContext.User.Claims.Where(p => p.Type == "JWT").Select(p => p.Value).First();
            }
        
        }

        public IEnumerable<AgendaViewModel> agendas { get; set; }
        public  void OnGet()
        {

        }
        public async Task<PartialViewResult> OnGetViewAllPartial()
        {
        
            agendas = await _agendaClient.ObterTodos(Token);
            return new PartialViewResult
            {
                ViewName = "_ViewAll",
                ViewData = new ViewDataDictionary<IEnumerable<AgendaViewModel>>(ViewData, agendas)
            };
        }

        public async Task<JsonResult> OnGetDetalhe(int id)
        {
            var Agenda = await _agendaClient.ObterPorId(id,Token);
            return new JsonResult(new { isValid = true, html = await _renderService.ToStringAsync("_Detalhe", Agenda) });
        }

        public async Task<JsonResult> OnGetCreateOrEditAsync(int id = 0)
        {
            if (id == 0)
                return new JsonResult(new { isValid = true, html = await _renderService.ToStringAsync("_CreateOrEdit", new AgendaViewModel()) });
            else
            {
                var Agenda = await _agendaClient.ObterPorId(id, Token);
                return new JsonResult(new { isValid = true, html = await _renderService.ToStringAsync("_CreateOrEdit", Agenda) });
            }
        }

        public async Task<JsonResult> OnPostCreateOrEditAsync(int id, AgendaViewModel agenda)
        {
            
            if (ModelState.IsValid)
            {
                if (id == 0)
                {
                
                        await _agendaClient.Adicionar(agenda, Token);

                    TempData["Sucesso"] = "Adicionador Com Sucesso";


                }
                else
                {
                     await _agendaClient.Atualizar(agenda, agenda.Id, Token);

                    TempData["Sucesso"] = "Atualizador Com Sucesso";
                }
                agendas = await _agendaClient.ObterTodos(Token);


                var html = await _renderService.ToStringAsync("_ViewAll", agendas);
                
                return new JsonResult(new { isValid = true, html = html, ViewData = "sadasdasd" });
            }
            else
            {
                var html = await _renderService.ToStringAsync("_CreateOrEdit", agenda);
                return new JsonResult(new { isValid = false, html = html });
            }
        }
    }
}
