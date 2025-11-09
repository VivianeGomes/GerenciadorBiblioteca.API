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
    public async Task<IActionResult> GetUsuarios()
    {
        var usuarios = await _usuarioService.ListarTodosAsync();
        return Ok(new { sucesso = true, dados = usuarios, erros = Array.Empty<string>() });
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetUsuario(Guid id)
    {
        var usuario = await _usuarioService.ObterPorIdAsync(id);
        if (usuario == null)
            return NotFound(new { sucesso = false, dados = (object?)null, erros = new[] { "Usuário não encontrado." } });

        return Ok(new { sucesso = true, dados = usuario, erros = Array.Empty<string>() });
    }

    [HttpPost]
    public async Task<IActionResult> PostUsuario([FromBody] CriarUsuarioDto dto)
    {
        try
        {
            var usuario = new Usuario(Guid.NewGuid(), dto.Nome!, dto.Email!);
            await _usuarioService.CadastrarAsync(usuario);

            return CreatedAtAction(nameof(GetUsuario), new { id = usuario.Id }, new { sucesso = true, dados = usuario, erros = Array.Empty<string>() });
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { sucesso = false, dados = (object?)null, erros = new[] { ex.Message } });
        }
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteUsuario(Guid id)
    {
        var removido = await _usuarioService.RemoverAsync(id);
        if (!removido)
            return NotFound(new { sucesso = false, dados = (object?)null, erros = new[] { "Usuário não encontrado." } });

        return NoContent();
    }
}
