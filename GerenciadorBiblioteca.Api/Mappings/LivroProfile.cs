using AutoMapper;
using GerenciadorBiblioteca.Api.DTOs.Livro;
using GerenciadorBiblioteca.Domain.Entities;

namespace GerenciadorBiblioteca.Api.Mappings
{
    public class LivroProfile : Profile
    {
        public LivroProfile()
        {
            // CriarLivroDto -> Livro (entrada)
            CreateMap<CriarLivroDto, Livro>();

            // Livro -> LivroDto (saída)
            CreateMap<Livro, LivroDto>();
        }
    }
}
