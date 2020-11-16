using System;
using System.Linq;
using System.Threading.Tasks;
using ControleCinemas.Business.Interfaces;
using ControleCinemas.Business.Models;
using ControleCinemas.Business.Models.Validations;

namespace ControleCinemas.Business.Services
{
    public class FilmeService : BaseService, IFilmeService
    {
        public IFilmeRepository _filmeRepositorio { get; set; }
        public FilmeService(INotificador notificador, IFilmeRepository filmeRepositorio) : base(notificador)
        {
            _filmeRepositorio = filmeRepositorio;
        }

        public async Task<bool> Adicionar(Filme filme)
        {
            if (!ExecutarValidacao(new FilmeValidation(), filme)) return false;

            if (_filmeRepositorio.Buscar(f => f.TituloOriginal == filme.TituloOriginal).Result.Any())
            {
                Notificar("Já existe um filme com este nome");
                return false;
            }

            await _filmeRepositorio.Adicionar(filme);
            return true;
        }

        public async Task<bool> Atualizar(Filme filme)
        {
            if (!ExecutarValidacao(new FilmeValidation(), filme)) return false;

            if (!_filmeRepositorio.Buscar(f => f.TituloOriginal == filme.TituloOriginal && f.Id == filme.Id).Result.Any())
            {
                Notificar("Não existe um cinema com este nome");
                return false;
            }

            await _filmeRepositorio.Atualizar(filme);
            return true;
        }

        public void Dispose()
        {
            _filmeRepositorio?.Dispose();
        }

        public async Task<bool> Remover(Guid id)
        {
            if (_filmeRepositorio.ObterCinemasPorFilme(id).Result.Any())
            {
                Notificar("O filme possui cinemas cadastrados");
                return false;
            }

            var ator = _filmeRepositorio.ObterAtorPorFilme(id);
            if (ator is null)
            {
                Notificar("O filme possui atores cadastrados");
                return false;
            }

            var genero = _filmeRepositorio.ObterGeneroPorFilme(id);
            if (genero is null)
            {
                Notificar("O filme possui generos cadastradas");
                return false;
            }

            var filme = await _filmeRepositorio.ObterPorId(id);
            if (filme is null)
            {
                Notificar("Cinema não encontrado.");
                return false;
            }

            await _filmeRepositorio.Remover(filme.Id);
            return true;
        }
    }
}