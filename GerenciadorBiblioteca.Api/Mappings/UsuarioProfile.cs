using AutoMapper;
using GerenciadorBiblioteca.Api.DTOs.Usuario;
using GerenciadorBiblioteca.Domain.Entities;

namespace GerenciadorBiblioteca.Api.Mappings
{
    public class UsuarioProfile : Profile
    {
        public UsuarioProfile()
        {
            // CriarUsuarioDto -> Usuario (entrada)
            CreateMap<CriarUsuarioDto, Usuario>();

            // Usuario -> UsuarioDto (saída)
            CreateMap<Usuario, UsuarioDto>();
        }
    }
}
