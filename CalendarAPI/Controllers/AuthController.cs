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
using Microsoft.Extensions.Caching.Memory;
using Microsoft.IdentityModel.Tokens;

namespace CalendarAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly IUserServiceInterface _userService;
        private readonly IMemoryCache memoryCache;
        public AuthController(IUserServiceInterface userService, IMemoryCache memoryCache )
        {
            _userService = userService;
            this.memoryCache = memoryCache;
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
                object value;
                memoryCache.TryGetValue($"Key{credencials.email}{credencials.password}", out value);
                if(!(value is null))
                {
                    return Ok(value);
                }
                var responseCredencials = _userService.CreateToken(credencials);
                memoryCache.Set($"Key{credencials.email}{credencials.password}", responseCredencials, new MemoryCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(30),
                    SlidingExpiration = TimeSpan.FromMinutes(30)
                });
                return Ok(responseCredencials);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }

        }


    }
}