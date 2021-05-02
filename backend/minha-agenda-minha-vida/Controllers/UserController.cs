using Microsoft.AspNetCore.Mvc;
using minha_agenda_minha_vida.Data;
using minha_agenda_minha_vida.Models;

namespace minha_agenda_minha_vida.Controllers
{
    [ApiController]
    [Route("[controller]/login")]
    public class UserController: ControllerBase
    {
        private readonly ILoginRepository _loginRepository;
        public UserController(ILoginRepository loginRepository){
            _loginRepository = loginRepository;
        }
        
        [HttpPost]
        public IActionResult Login(User us){
            var user = _loginRepository.MakeLogin(us.Name, us.Password);
            if(user != null)
                return Ok(new {accessToken = user.Token});
            
            return BadRequest();
        }
    }
}