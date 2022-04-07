using Agenda.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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
            var userId = Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            
            var res = _agendaRepository.GetAll(userId).OrderBy(x=>x.ScheduleDate).ToList();
            
            return View(res);
        }

        [Authorize]
        public IActionResult Detail(Guid Id)
        {
            var res = _agendaRepository.GetById(Id);

            return View(res);
        }

        [Authorize]
        [HttpGet]
        public IActionResult Create()
        {
            var res = new Models.Agenda();
            
            return View("~/Views/Agenda/CreateEdit.cshtml", res);
        }

        [Authorize]
        [HttpPost]
        public IActionResult Create(Models.Agenda agenda)
        {
            try
            {
                agenda.UserId = Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
                _agendaRepository.Save(agenda);
                return Ok(new { Message = "Cadastrado com sucesso!" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = "Erro ao cadastrar." });
            }
        }

        [Authorize]
        [HttpGet]
        public IActionResult Edit(Guid Id)
        {
            var res = _agendaRepository.GetById(Id);

            return View("~/Views/Agenda/CreateEdit.cshtml", res);
        }

        [Authorize]
        [HttpPost]
        public IActionResult Update(Models.Agenda agenda)
        {
            try
            {
                _agendaRepository.Save(agenda);
                return Ok(new { Message = "Atualizado com sucesso!" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = "Erro ao cadastrar." });
            }
        }

        [Authorize]
        public IActionResult Delete(string Id)
        {
            try
            {
                var agenda = _agendaRepository.GetById(Guid.Parse(Id));
                _agendaRepository.Delete(agenda);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = "Erro ao cadastrar." });
            }
        }

    }
}
