using Agenda.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Agenda.Controllers
{
    public class AgendaController : Controller
    {
        private readonly IAgendaRepository _agendaRepository;
        public AgendaController(IAgendaRepository agendaRepository)
        {
            _agendaRepository = agendaRepository;
        }

        [Authorize]
        public IActionResult Index()
        {
            var res = _agendaRepository.GetAll();
            
            return View(res);
        }


    }
}
