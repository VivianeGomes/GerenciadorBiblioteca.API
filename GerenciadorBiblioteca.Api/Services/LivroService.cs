using AutoMapper;
using GerenciadorBiblioteca.Api.DTOs.Livro;
using GerenciadorBiblioteca.Api.Interfaces;
using GerenciadorBiblioteca.Domain.Entities;
using GerenciadorBiblioteca.Domain.Interfaces;
using GerenciadorBiblioteca.Infra.Validators;

namespace GerenciadorBiblioteca.Api.Services
{
    public class LivroService : ILivroService
    {
        private readonly ILivroRepository _livroRepository;
        private readonly IMapper _mapper;

        public LivroService(ILivroRepository livroRepository, IMapper mapper)
        {
            _livroRepository = livroRepository;
            _mapper = mapper;
        }

        public LivroDto Cadastrar(CriarLivroDto dto)
        {
            // Usa o AutoMapper para converter DTO → Entidade
            var livro = _mapper.Map<Livro>(dto);
            livro.Id = Guid.NewGuid();

            Validar(livro);
            _livroRepository.Adicionar(livro);

            // Usa o AutoMapper para converter Entidade → DTO
            return _mapper.Map<LivroDto>(livro);
        }

        public bool Validar(Livro livro)
        {
            var validator = new LivroValidator();

            if (!validator.IsValid(livro, out var errors))
            {
                throw new ArgumentException(string.Join("; ", errors));
            }

            return true;
        }

        public IEnumerable<LivroDto> ListarTodos()
        {
            var livros = _livroRepository.ListarTodos();
            return _mapper.Map<IEnumerable<LivroDto>>(livros);
        }

        public LivroDto? ObterPorId(Guid id)
        {
            var livro = _livroRepository.ObterPorId(id);
            return livro == null ? null : _mapper.Map<LivroDto>(livro);
        }

        public bool Remover(Guid id)
        {
            return _livroRepository.Remover(id);
        }
    }
}
