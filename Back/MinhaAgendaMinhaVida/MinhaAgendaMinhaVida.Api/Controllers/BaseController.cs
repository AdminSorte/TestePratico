using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace MinhaAgendaMinhaVida.Api.Controllers
{
    public class BaseController : ControllerBase
    {
        [NonAction]
        public IActionResult BaseResponse(object result, IReadOnlyCollection<string> notifications = null)
        {
            if (notifications != null && notifications.Any())
                return BadRequest(new
                {
                    success = false,
                    errors = notifications
                });

            try
            {
                return Ok(new
                {
                    success = true,
                    data = result
                });
            }
            catch
            {
                return BadRequest(new
                {
                    success = false,
                    errors = new[] {"Internal Server Error."}
                });
            }
        }
    }
}