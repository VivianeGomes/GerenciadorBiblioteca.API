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

        public async Task<LivroDto> CadastrarAsync(CriarLivroDto dto)
        {
            var livro = _mapper.Map<Livro>(dto);
            livro.Id = Guid.NewGuid();

            Validar(livro);
            await _livroRepository.AdicionarAsync(livro);

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

        public async Task<IEnumerable<LivroDto>> ListarTodosAsync()
        {
            var livros = await _livroRepository.ListarTodosAsync();
            return _mapper.Map<IEnumerable<LivroDto>>(livros);
        }

        public async Task<LivroDto?> ObterPorIdAsync(Guid id)
        {
            var livro = await _livroRepository.ObterPorIdAsync(id);
            return livro == null ? null : _mapper.Map<LivroDto>(livro);
        }

        public async Task<bool> RemoverAsync(Guid id)
        {
            return await _livroRepository.RemoverAsync(id);
        }
    }
}
