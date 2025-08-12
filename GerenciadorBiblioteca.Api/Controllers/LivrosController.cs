using Microsoft.AspNetCore.Mvc;

namespace GerenciadorBiblioteca.Api.Controllers
{
    [ApiController]
    [Route("api/livros")]
    public class LivrosController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetLivros()
        {
            return Ok(new { sucesso = true, dados = new[] { "Livro A", "Livro B" }, erros = new string[] { } });
        }

        [HttpGet("{id}")]
        public IActionResult GetLivro(int id)
        {
            return Ok(new { sucesso = true, dados = $"Livro {id}", erros = new string[] { } });
        }

        [HttpPost]
        public IActionResult PostLivro([FromBody] string livro)
        {
            return CreatedAtAction(nameof(GetLivro), new { id = 1 }, new { sucesso = true, dados = livro, erros = new string[] { } });
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteLivro(int id)
        {
            return Ok(new { sucesso = true, dados = $"Livro {id} removido", erros = new string[] { } });
        }
    }
}
