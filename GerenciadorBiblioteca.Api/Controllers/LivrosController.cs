using GerenciadorBiblioteca.Api.DTOs.Livro;
using GerenciadorBiblioteca.Api.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorBiblioteca.Api.Controllers;

[ApiController]
[Route("api/livros")]
public class LivrosController : ControllerBase
{
    private readonly ILivroService _livroService;

    public LivrosController(ILivroService livroService)
    {
        _livroService = livroService;
    }

    [HttpGet]
    public IActionResult GetLivros()
    {
        var livros = _livroService.ListarTodos();
        return Ok(new { sucesso = true, dados = livros, erros = Array.Empty<string>() });
    }

    [HttpGet("{id:guid}")]
    public IActionResult GetLivro(Guid id)
    {
        var livro = _livroService.ObterPorId(id);
        if (livro == null)
            return NotFound(new { sucesso = false, dados = (object?)null, erros = new[] { "Livro não encontrado." } });

        return Ok(new { sucesso = true, dados = livro, erros = Array.Empty<string>() });
    }

    [HttpPost]
    public IActionResult PostLivro([FromBody] CriarLivroDto dto)
    {
        try
        {
            var livro = _livroService.Cadastrar(dto);
            return CreatedAtAction(nameof(GetLivro), new { id = livro.Id }, new { sucesso = true, dados = livro, erros = Array.Empty<string>() });
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { sucesso = false, dados = (object?)null, erros = new[] { ex.Message } });
        }
    }

    [HttpDelete("{id:guid}")]
    public IActionResult DeleteLivro(Guid id)
    {
        var removido = _livroService.Remover(id);
        if (!removido)
            return NotFound(new { sucesso = false, dados = (object?)null, erros = new[] { "Livro não encontrado." } });

        return NoContent();
    }
}
