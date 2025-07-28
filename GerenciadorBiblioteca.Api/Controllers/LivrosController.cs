using Microsoft.AspNetCore.Mvc;

namespace GerenciadorBiblioteca.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LivrosController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new { sucesso = true, dados = new[] { "Livro A", "Livro B" }, erros = new string[] { } });
        }
    }
}
