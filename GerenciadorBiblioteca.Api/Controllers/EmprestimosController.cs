using GerenciadorBiblioteca.Api.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorBiblioteca.Api.Controllers;

[ApiController]
[Route("api/emprestimos")]
public class EmprestimosController : ControllerBase
{
    private readonly IEmprestimoService _emprestimoService;

    public EmprestimosController(IEmprestimoService emprestimoService)
    {
        _emprestimoService = emprestimoService;
    }

    [HttpGet]
    public async Task<IActionResult> GetEmprestimos()
    {
        var emprestimos = await _emprestimoService.ListarTodosAsync();
        return Ok(new { sucesso = true, dados = emprestimos, erros = Array.Empty<string>() });
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetEmprestimo(Guid id)
    {
        var emprestimo = await _emprestimoService.ObterPorIdAsync(id);
        if (emprestimo == null)
            return NotFound(new { sucesso = false, dados = (object?)null, erros = new[] { "Empréstimo não encontrado." } });

        return Ok(new { sucesso = true, dados = emprestimo, erros = Array.Empty<string>() });
    }

    [HttpPost]
    public async Task<IActionResult> RegistrarEmprestimo(Guid idLivro, Guid idUsuario)
    {
        try
        {
            await _emprestimoService.RegistrarEmprestimoAsync(idLivro, idUsuario);
            return Ok(new { sucesso = true, dados = "Empréstimo registrado com sucesso!", erros = Array.Empty<string>() });
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { sucesso = false, dados = (object?)null, erros = new[] { ex.Message } });
        }
    }

    [HttpPut("{id:guid}/devolucao")]
    public async Task<IActionResult> Devolver(Guid id)
    {
        try
        {
            await _emprestimoService.DevolverAsync(id);
            return Ok(new { sucesso = true, dados = "Livro devolvido com sucesso!", erros = Array.Empty<string>() });
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { sucesso = false, dados = (object?)null, erros = new[] { ex.Message } });
        }
    }

    [HttpGet("{id:guid}/atraso")]
    public async Task<IActionResult> MensagemDeAtraso(Guid id)
    {
        try
        {
            var mensagem = await _emprestimoService.GerarMensagemDeAtrasoAsync(id);
            return Ok(new { sucesso = true, dados = mensagem, erros = Array.Empty<string>() });
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { sucesso = false, dados = (object?)null, erros = new[] { ex.Message } });
        }
    }
}
