using Microsoft.AspNetCore.Mvc;

namespace SO.Agenda.Presentation.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
