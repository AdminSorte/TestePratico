using Microsoft.AspNetCore.Mvc;
using MinhaAgendaMinhaVida.Domain.Interfaces.Service;

namespace MinhaAgendaMinhaVida.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SampleController : BaseController
    {
        private readonly ISampleService _sampleService;

        public SampleController(ISampleService sampleService)
        {
            _sampleService = sampleService;
        }

        [HttpGet]
        public IActionResult Get(int id)
        {
            return BaseResponse(_sampleService.Get(id));
        }
    }
}