using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace TestePratico.Web.Controllers
{
    public class AgendaController : Controller
    {
        private Services.APIService _apiService;

        public AgendaController()
        {
            _apiService = new Services.APIService();
        }
        
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<JsonResult> ListaAgendas(int jtStartIndex = 0, int jtPageSize = 0, string jtSorting = null)
        {
            try
            {
                var listaAgendas = new List<Models.Agenda>();

                listaAgendas = await _apiService.GetAgendasAsync();

                int totalLinhas = listaAgendas.Count;

                return Json(new { Result = "OK", Records = listaAgendas, TotalRecordCount = totalLinhas });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }

        [HttpPost]
        public async Task<JsonResult> IncluirAgenda(Models.Agenda agenda)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Json(new { Result = "ERROR", Message = "Formulário inválido, por favor, preencha os campos obrigatórios." });
                }

                var objAgenda = new Models.Agenda()
                {
                    Descricao = agenda.Descricao,
                    Titulo = agenda.Titulo,
                };

                await _apiService.AddAgendaAsync(objAgenda);

                return Json(new { Result = "OK", Record = objAgenda });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }

        [HttpPost]
        public async Task<JsonResult> AtualizarAgenda(Models.Agenda agenda)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Json(new { Result = "ERROR", Message = "Formulário inválido, por favor, preencha os campos obrigatórios." });
                }

                var objAgenda = new Models.Agenda()
                {
                    ID = agenda.ID,
                    Descricao = agenda.Descricao,
                    Titulo = agenda.Titulo,
                    DataCadastro = agenda.DataCadastro
                };

                await _apiService.UpdateAgendaAsync(objAgenda);

                return Json(new { Result = "OK" });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }

        [HttpPost]
        public async Task<JsonResult> DeletarAgenda(int ID)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Json(new { Result = "ERROR", Message = "Formulário inválido, por favor, preencha os campos obrigatórios." });
                }

                await _apiService.DeletaAgendaAsync(ID);

                return Json(new { Result = "OK" });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }
    }
}