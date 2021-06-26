using Microsoft.AspNetCore.Mvc;
using MinhaAgendaMinhaVida.Domain.Commands.Agenda;
using MinhaAgendaMinhaVida.Domain.Interfaces.Service;

namespace MinhaAgendaMinhaVida.Api.Controllers
{
    [ApiController]
    public class AgendaController : BaseController
    {
        private readonly IAgendaService _agendaService;

        public AgendaController(IAgendaService agendaService) => _agendaService = agendaService;

        [HttpPost("v1/agenda/list")]
        public IActionResult List(SelectAgendaCommand command) => BaseResponse(_agendaService.List(command));
    }
}