using GerenciadorBiblioteca.Api.Interfaces;
using GerenciadorBiblioteca.Api.Services;
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
    public IActionResult GetEmprestimos()
    {
        var emprestimos = _emprestimoService.ListarTodos();
        return Ok(new { sucesso = true, dados = emprestimos, erros = Array.Empty<string>() });
    }

    [HttpGet("{id:guid}")]
    public IActionResult GetEmprestimo(Guid id)
    {
        var emprestimo = _emprestimoService.ObterPorId(id);
        if (emprestimo == null)
            return NotFound(new { sucesso = false, dados = (object?)null, erros = new[] { "Empréstimo não encontrado." } });

        return Ok(new { sucesso = true, dados = emprestimo, erros = Array.Empty<string>() });
    }

    [HttpPost]
    public IActionResult RegistrarEmprestimo(Guid idLivro, Guid idUsuario)
    {
        try
        {
            _emprestimoService.RegistrarEmprestimo(idLivro, idUsuario);
            return Ok(new { sucesso = true, dados = "Empréstimo registrado com sucesso!", erros = Array.Empty<string>() });
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { sucesso = false, dados = (object?)null, erros = new[] { ex.Message } });
        }
    }

    [HttpPut("{id:guid}/devolucao")]
    public IActionResult Devolver(Guid id)
    {
        try
        {
            _emprestimoService.Devolver(id);
            return Ok(new { sucesso = true, dados = "Livro devolvido com sucesso!", erros = Array.Empty<string>() });
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { sucesso = false, dados = (object?)null, erros = new[] { ex.Message } });
        }
    }

    [HttpGet("{id:guid}/atraso")]
    public IActionResult MensagemDeAtraso(Guid id)
    {
        try
        {
            var mensagem = _emprestimoService.GerarMensagemDeAtraso(id);
            return Ok(new { sucesso = true, dados = mensagem, erros = Array.Empty<string>() });
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { sucesso = false, dados = (object?)null, erros = new[] { ex.Message } });
        }
    }
}
