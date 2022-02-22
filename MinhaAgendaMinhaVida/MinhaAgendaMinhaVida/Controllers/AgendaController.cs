using Microsoft.AspNetCore.Mvc;
using MinhaAgendaMinhaVida.Models;
using MinhaAgendaMinhaVida.Services.Interfaces;

namespace MinhaAgendaMinhaVida.Controllers
{
    [Route("Agenda")]
    public class AgendaController : Controller
    {
        private readonly IServicoDeAgenda _servicoDeAgenda;

        public AgendaController(IServicoDeAgenda servicoDeAgenda)
        {
            _servicoDeAgenda = servicoDeAgenda;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var agendamentos = new List<Agendamento>();
            var usuarioId = HttpContext.Session.GetInt32(Constantes.USUARIO_ID);

            if(usuarioId.HasValue)
                agendamentos = _servicoDeAgenda.ObterAgendamentos(usuarioId.Value);

            return View(agendamentos);
        }

        [HttpGet("pesquisar")]
        public ActionResult Pesquisar(string texto)
        {
            var agendamentos = new List<Agendamento>();
            var usuarioId = HttpContext.Session.GetInt32(Constantes.USUARIO_ID);

            if (usuarioId.HasValue)
                agendamentos = _servicoDeAgenda.ObterAgendamentos(usuarioId.Value, texto);

            return PartialView("ListagemAgendamentos", agendamentos);
        }

        [HttpGet("Edit/{id}/{apenasLeitura}")]
        public ActionResult Edit(int id, bool apenasLeitura)
        {
            try
            {
                var usuarioId = HttpContext.Session.GetInt32(Constantes.USUARIO_ID);
                if (!usuarioId.HasValue)
                    throw new Exception("Usuário não autenticado");

                Agendamento agendamento;

                if(id > 0)
                {
                    agendamento = _servicoDeAgenda.ObterAgendamento(usuarioId.Value, id);
                }
                else
                    agendamento = new Agendamento { Id = 0, Data = DateTime.Today.AddDays(1) };

                if(apenasLeitura)
                    return View("ModalVisualizar", agendamento);                
                else
                    return View("ModalEditar", agendamento);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("salvar")]
        public ActionResult Salvar(Agendamento agendamento)
        {
            try
            {
                var usuarioId = HttpContext.Session.GetInt32(Constantes.USUARIO_ID);
                if (!usuarioId.HasValue)
                    throw new Exception("Usuário não autenticado");

                Agendamento resultado;
                if (agendamento.Id == 0)
                {
                    resultado = _servicoDeAgenda.Adicionar(usuarioId.Value, agendamento);
                    return Ok(resultado);
                }
                else
                {
                    resultado = _servicoDeAgenda.Atualizar(agendamento);

                    return Ok("Atualizado com sucesso!");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPut("Atualizar")]
        public ActionResult Atualizar(Agendamento agendamento)
        {
            return Salvar(agendamento);
        }


        [HttpDelete("Remover")]
        public ActionResult Remover(int agendamentoId)
        {
            try
            {
                var usuarioId = HttpContext.Session.GetInt32(Constantes.USUARIO_ID);
                if (!usuarioId.HasValue)
                    throw new Exception("Usuário não autenticado");

                var sucesso = _servicoDeAgenda.Remover(usuarioId.Value, agendamentoId);
                if (sucesso) return Ok();
                else return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
