using GerenciadorBiblioteca.Api.DTOs.Usuario;
using GerenciadorBiblioteca.Api.Interfaces;
using GerenciadorBiblioteca.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorBiblioteca.Api.Controllers;

[ApiController]
[Route("api/usuarios")]
public class UsuariosController : ControllerBase
{
    private readonly IUsuarioService _usuarioService;

    public UsuariosController(IUsuarioService usuarioService)
    {
        _usuarioService = usuarioService;
    }

    [HttpGet]
    public IActionResult GetUsuarios()
    {
        var usuarios = _usuarioService.ListarTodos();
        return Ok(new { sucesso = true, dados = usuarios, erros = Array.Empty<string>() });
    }

    [HttpGet("{id:guid}")]
    public IActionResult GetUsuario(Guid id)
    {
        var usuario = _usuarioService.ObterPorId(id);
        if (usuario == null)
            return NotFound(new { sucesso = false, dados = (object?)null, erros = new[] { "Usuário não encontrado." } });

        return Ok(new { sucesso = true, dados = usuario, erros = Array.Empty<string>() });
    }

    [HttpPost]
    public IActionResult PostUsuario([FromBody] CriarUsuarioDto dto)
    {
        try
        {
            var usuario = new Usuario(Guid.NewGuid(), dto.Nome!, dto.Email!);
            _usuarioService.Cadastrar(usuario);

            return CreatedAtAction(nameof(GetUsuario), new { id = usuario.Id }, new { sucesso = true, dados = usuario, erros = Array.Empty<string>() });
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { sucesso = false, dados = (object?)null, erros = new[] { ex.Message } });
        }
    }

    [HttpDelete("{id:guid}")]
    public IActionResult DeleteUsuario(Guid id)
    {
        var removido = _usuarioService.Remover(id);
        if (!removido)
            return NotFound(new { sucesso = false, dados = (object?)null, erros = new[] { "Usuário não encontrado." } });

        return NoContent();
    }
}
