using System.Runtime.Intrinsics;
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

        [HttpPost("v1/[controller]/list")]
        public IActionResult List(SelectAgendaCommand command) => BaseResponse(_agendaService.List(command));

        [HttpPost("vi/[controller]/add")]
        public IActionResult Add(InsertAgendaCommand command) => BaseResponse(_agendaService.Add(command));
    }
}