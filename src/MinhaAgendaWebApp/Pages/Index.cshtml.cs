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

namespace MinhaAgendaWebApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IAgendaClient _agendaClient;
        private readonly IRazorRenderService _renderService;
        public IndexModel(ILogger<IndexModel> logger, IAgendaClient agendaClient, IRazorRenderService razorRenderService)
        {
            _logger = logger;
            _agendaClient = agendaClient;
            _renderService = razorRenderService;
        }

        public IEnumerable<AgendaViewModel> agendas { get; set; }
        public  void OnGet()
        {

        }
  


        public async Task<PartialViewResult> OnGetViewAllPartial()
        {
            agendas = await _agendaClient.ObterTodos();
            return new PartialViewResult
            {
                ViewName = "_ViewAll",
                ViewData = new ViewDataDictionary<IEnumerable<AgendaViewModel>>(ViewData, agendas)
            };
        }

        public async Task<JsonResult> OnGetDetalhe(int id)
        {

            var Agenda = await _agendaClient.ObterPorId(id);
            return new JsonResult(new { isValid = true, html = await _renderService.ToStringAsync("_Detalhe", Agenda) });
        }

        public async Task<JsonResult> OnGetCreateOrEditAsync(int id = 0)
        {
            if (id == 0)
                return new JsonResult(new { isValid = true, html = await _renderService.ToStringAsync("_CreateOrEdit", new AgendaViewModel()) });
            else
            {
                var Agenda = await _agendaClient.ObterPorId(id);
                return new JsonResult(new { isValid = true, html = await _renderService.ToStringAsync("_CreateOrEdit", Agenda) });
            }
        }

        public async Task<JsonResult> OnPostCreateOrEditAsync(int id, AgendaViewModel agenda)
        {
            if (ModelState.IsValid)
            {
                if (id == 0)
                {
                
                        await _agendaClient.Adicionar(agenda);
                }
                else
                {
                     await _agendaClient.Atualizar(agenda, agenda.Id);

                }
                agendas = await _agendaClient.ObterTodos();
                var html = await _renderService.ToStringAsync("_ViewAll", agendas);
                return new JsonResult(new { isValid = true, html = html });
            }
            else
            {
                var html = await _renderService.ToStringAsync("_CreateOrEdit", agenda);
                return new JsonResult(new { isValid = false, html = html });
            }
        }
    }
}
