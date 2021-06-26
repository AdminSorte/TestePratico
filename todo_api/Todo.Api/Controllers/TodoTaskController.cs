using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Todo.Application.Business.Interface;
using Todo.Application.Dto.TodoTask;

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

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateTodoTaskDto data) {
            var result = await _todoTaskBusiness.CreateAsync(data);
            
            if (result.Success)
                return Ok(result);
            
            return BadRequest(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateTodoTaskDto data) {
            var result = await _todoTaskBusiness.UpdateAsync(data);
            
            if (result.Success)
                return Ok(result);
            
            return BadRequest(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Remove([FromQuery] int id) {
            var result = await _todoTaskBusiness.RemoveAsync(id);
            
            if (result.Success)
                return Ok(result);
            
            return BadRequest(result);
        }
    }
}