using AutoMapper;
using GerenciadorBiblioteca.Api.DTOs.Livro;
using GerenciadorBiblioteca.Domain.Entities;

namespace GerenciadorBiblioteca.Api.Mappings
{
    public class LivroProfile : Profile
    {
        public LivroProfile()
        {
            // DTO -> Livro
            CreateMap<LivroDto, Livro>()
                .ForMember(dest => dest.Titulo, opt => opt.MapFrom(src => src.Titulo ?? string.Empty))
                .ForMember(dest => dest.Autor, opt => opt.MapFrom(src => src.Autor ?? string.Empty))
                .ForMember(dest => dest.Genero, opt => opt.MapFrom(src => src.Genero ?? string.Empty));

            // Livro -> DTO
            CreateMap<Livro, LivroDto>();
        }
    }
}
