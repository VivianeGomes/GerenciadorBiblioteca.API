using Microsoft.AspNetCore.Mvc;

namespace GerenciadorBiblioteca.Api.Controllers
{
    public class UsuariosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
