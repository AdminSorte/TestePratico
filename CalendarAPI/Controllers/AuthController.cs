using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using CalendarAPI.BD;
using CalendarAPI.Models;
using CalendarAPI.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace CalendarAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly IUserServiceInterface _userService;
        public AuthController(IUserServiceInterface userService)
        {
            _userService = userService;
        }
        /// <summary>
        /// Create a token to authentification
        /// </summary>
        /// <param name="credencials"></param>
        /// <returns></returns>
        [HttpPost()]
        public IActionResult GetToken([FromBody]AuthModel credencials)
        {
            try
            {
                var responseCredencials = _userService.CreateToken(credencials);
                return Ok(responseCredencials);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }

        }


    }
}