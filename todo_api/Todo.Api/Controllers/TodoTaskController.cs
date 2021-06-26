using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Todo.Application.Business.Interface;

namespace Todo.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class TodoTaskController : Controller
    {
        private readonly ITodoTaskBusiness _todoTaskBusiness;

        public TodoTaskController(ITodoTaskBusiness todoTaskBusiness)
        {
            _todoTaskBusiness = todoTaskBusiness;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() {
            var result = await _todoTaskBusiness.GetAllAsync();
            
            if (result.Success)
                return Ok(result);
            
            return BadRequest(result);
        }
    }
}