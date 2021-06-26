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

        [HttpPost("v1/[controller]/add")]
        public IActionResult Add(InsertAgendaCommand command) => BaseResponse(_agendaService.Add(command));

        [HttpGet("v1/[controller]/view/{id}")]
        public IActionResult View(int id) => BaseResponse(_agendaService.View(id));

        [HttpDelete("v1/[controller]/delete/{id}")]
        public IActionResult Delete(int id) => BaseResponse(_agendaService.Delete(id));

        [HttpPut("v1/[controller]/edit")]
        public IActionResult Edit(UpdateAgendaCommand command) => BaseResponse(_agendaService.Edit(command));
    }
}