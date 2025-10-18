using AutoMapper;
using GerenciadorBiblioteca.Api.DTOs.Emprestimo;
using GerenciadorBiblioteca.Domain.Entities;

namespace GerenciadorBiblioteca.Api.Mappings
{
    public class EmprestimoProfile : Profile
    {
        public EmprestimoProfile()
        {
            // RegistrarEmprestimoDto -> Emprestimo (entrada)
            CreateMap<CriarEmprestimoDto, Emprestimo>();

            // Emprestimo -> EmprestimoDto (saída)
            CreateMap<Emprestimo, EmprestimoDto>();
        }
    }
}
