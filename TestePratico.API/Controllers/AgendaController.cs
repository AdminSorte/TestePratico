using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace TestePratico.API.Controllers
{
    public class AgendaController : ApiController
    {
        private BLL.Objects.Agenda _objAgendaBLL;

        public AgendaController()
        {
            _objAgendaBLL = new BLL.Objects.Agenda();
        }

        [HttpGet]
        public IHttpActionResult ListarAgendas()
        {
            var listaAgendas = _objAgendaBLL.ListarAgendas();

            var result = listaAgendas.Select(p => new Models.AgendaDTO()
            {
                ID = p.ID,
                Descricao = p.Descricao,
                Titulo = p.Titulo,
                DataCadastro = p.DataCadastro
            }).ToList();

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpGet]
        [ResponseType(typeof(Models.AgendaDTO))]
        public IHttpActionResult ObterAgenda(int id)
        {
            try
            {
                var objAgenda = _objAgendaBLL.ObterAgenda(id);

                if (objAgenda == null)
                    throw new Exception("Agenda não encontrada!");

                var listaAgenda = new List<Model.Entity.Agenda>();

                listaAgenda.Add(objAgenda);

                var result = listaAgenda.Select(p =>
                            new Models.AgendaDTO()
                            {
                                ID = p.ID,
                                Descricao = p.Descricao,
                                Titulo = p.Titulo,
                                DataCadastro = p.DataCadastro
                            }).SingleOrDefault(p => p.ID == id);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return Json(new { OK = false, Mensagem = ex.Message });
            }
        }

        [HttpPost]
        [ResponseType(typeof(Models.AgendaDTO))]
        public IHttpActionResult IncluirAgenda(Model.Entity.Agenda agenda)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = _objAgendaBLL.Incluir(agenda);

                if (!result)
                    return NotFound();

                var objAgendaDTO = new Models.AgendaDTO()
                {
                    ID = agenda.ID,
                    Descricao = agenda.Descricao,
                    Titulo = agenda.Titulo
                };

                return CreatedAtRoute("DefaultApi", new { id = agenda.ID }, objAgendaDTO);
            }
            catch (Exception ex)
            {
                return Json(new { OK = false, Mensagem = ex.Message });
            }
        }

        [HttpPut]
        [ResponseType(typeof(Models.AgendaDTO))]
        public IHttpActionResult AlterarAgenda(Model.Entity.Agenda agenda)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                agenda.DataCadastro = DateTime.Now;

                var result = _objAgendaBLL.Alterar(agenda);

                if (!result)
                    return NotFound();

                var objAgendaDTO = new Models.AgendaDTO()
                {
                    ID = agenda.ID,
                    Descricao = agenda.Descricao,
                    Titulo = agenda.Titulo,
                    DataCadastro = agenda.DataCadastro
                };

                return CreatedAtRoute("DefaultApi", new { id = agenda.ID }, objAgendaDTO);
            }
            catch (Exception ex)
            {
                return Json(new { OK = false, Mensagem = ex.Message });
            }
        }

        [HttpDelete]
        [ResponseType(typeof(Models.AgendaDTO))]
        public IHttpActionResult ExcluirAgenda(int id)
        {
            try
            {
                var objAgenda = _objAgendaBLL.ObterAgenda(id);

                if (objAgenda == null)
                    throw new Exception("Agenda não encontrada!");

                var result = _objAgendaBLL.Excluir(objAgenda);

                if (!result)
                    return NotFound();

                return Ok();   
            }
            catch (Exception ex)
            {
                return Json(new { OK = false, Mensagem = ex.Message });
            }
        }
    }
}
