using Microsoft.AspNetCore.Mvc;

namespace GerenciadorBiblioteca.Api.Controllers
{
    public class EmprestimosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
