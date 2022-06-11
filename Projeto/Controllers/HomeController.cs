using Microsoft.AspNetCore.Mvc;

namespace Projeto.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Receitas()
        {
            return View();
        }

        public IActionResult Saiba()
        {
            return View();
        }
    }
}
