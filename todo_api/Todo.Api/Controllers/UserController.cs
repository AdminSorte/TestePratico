using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Todo.Application.Business.Interface;
using Todo.Application.Dto.User;

namespace Todo.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class UserController : Controller
    {
        private readonly IUserBusiness _userBusiness;

        public UserController(IUserBusiness userBusiness)
        {
            _userBusiness = userBusiness;
        }

        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginDto data) {
            var result = await _userBusiness.Login(data);
            
            if (result.Success)
                return Ok(result);
            
            return BadRequest(result);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Create([FromBody] CreateUserDto data) {
            var result = await _userBusiness.CreateAsync(data);
            
            if (result.Success)
                return Ok(result);
            
            return BadRequest(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateUserDto data) {
            var result = await _userBusiness.UpdateAsync(data);
            
            if (result.Success)
                return Ok(result);
            
            return BadRequest(result);
        }

        [HttpPut("changepassword")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordDto data) {
            var result = await _userBusiness.ChangePasswordAsync(data);
            
            if (result.Success)
                return Ok(result);
            
            return BadRequest(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Remove() {
            var result = await _userBusiness.RemoveAsync();
            
            if (result.Success)
                return Ok(result);
            
            return BadRequest(result);
        }
    }
}