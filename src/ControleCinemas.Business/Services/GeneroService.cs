using System;
using System.Linq;
using System.Threading.Tasks;
using ControleCinemas.Business.Interfaces;
using ControleCinemas.Business.Models;
using ControleCinemas.Business.Models.Validations;

namespace ControleCinemas.Business.Services
{
    public class GeneroService : BaseService, IGeneroService
    {
        public IGeneroRepository _generoRepositorio { get; set; }
        public GeneroService(INotificador notificador, IGeneroRepository generoRepositorio) : base(notificador)
        {
            _generoRepositorio = generoRepositorio;
        }

        public async Task<bool> Adicionar(Genero genero)
        {
            if (!ExecutarValidacao(new GeneroValidation(), genero)) return false;

            if (_generoRepositorio.Buscar(f => f.Descricao == genero.Descricao).Result.Any())
            {
                Notificar("Já existe um gênero com este nome");
                return false;
            }

            await _generoRepositorio.Adicionar(genero);
            return true;
        }

        public async Task<bool> Atualizar(Genero genero)
        {
            if (!ExecutarValidacao(new GeneroValidation(), genero)) return false;

            if (!_generoRepositorio.Buscar(f => f.Descricao == genero.Descricao && f.Id == genero.Id).Result.Any())
            {
                Notificar("Não existe um gênero com este nome");
                return false;
            }

            await _generoRepositorio.Atualizar(genero);
            return true;
        }

        public void Dispose()
        {
            _generoRepositorio?.Dispose();
        }

        public async Task<bool> Remover(Guid id)
        {
            if (_generoRepositorio.ObterFilmesPorGenero(id).Result.Any())
            {
                Notificar("O gênero possui filmes cadastrados");
                return false;
            }

            var genero = await _generoRepositorio.ObterPorId(id);
            if (genero is null)
            {
                Notificar("Gênero não encontrado.");
                return false;
            }

            await _generoRepositorio.Remover(genero.Id);
            return true;
        }
    }
}