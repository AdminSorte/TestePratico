using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MinhaAgendaMinhaVida.Models;
using MinhaAgendaMinhaVida.Services.Interfaces;

namespace MinhaAgendaMinhaVida.Controllers
{
    [Route("Login")]
    [Route("")]
    public class LoginController : Controller
    {
        private readonly IServicoDeUsuario _servicoDeUsuario;

        public LoginController(IServicoDeUsuario servicoDeUsuario)
        {
            _servicoDeUsuario = servicoDeUsuario;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            return View("Login");
        }

        [HttpPost("logar")]
        [AllowAnonymous]
        public ActionResult Login(string usuario, string senha)
        {
            try
            {
                var user = _servicoDeUsuario.Login(usuario, senha);
                HttpContext.Session.SetString(Constantes.TOKEN, user.Token);
                HttpContext.Session.SetInt32(Constantes.USUARIO_ID, user.Id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
                
            }
        }
    }
}
