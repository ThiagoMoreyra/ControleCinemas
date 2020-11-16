using System.Linq;
using System;
using System.Threading.Tasks;
using ControleCinemas.Business.Interfaces;
using ControleCinemas.Business.Models;
using ControleCinemas.Business.Models.Validations;

namespace ControleCinemas.Business.Services
{
    public class AtorService : BaseService, IAtorService
    {
        public IAtorRepository _atorRepositorio { get; set; }
        public AtorService(INotificador notificador, IAtorRepository atorRepositorio) : base(notificador)
        {
            _atorRepositorio = atorRepositorio;
        }

        public async Task<bool> Adicionar(Ator ator)
        {
            if (!ExecutarValidacao(new AtorValidation(), ator)) return false;

            if (_atorRepositorio.Buscar(f => f.Nome == ator.Nome).Result.Any())
            {
                Notificar("Já existe um Ator com este nome");
                return false;
            }

            await _atorRepositorio.Adicionar(ator);
            return true;
        }

        public async Task<bool> Atualizar(Ator ator)
        {
            if (!ExecutarValidacao(new AtorValidation(), ator)) return false;

            if (!_atorRepositorio.Buscar(f => f.Nome == ator.Nome && f.Id == ator.Id).Result.Any())
            {
                Notificar("Não existe um Ator com este nome");
                return false;
            }

            await _atorRepositorio.Atualizar(ator);
            return true;
        }

        public void Dispose()
        {
            _atorRepositorio?.Dispose();
        }

        public async Task<bool> Remover(Guid id)
        {
            if (_atorRepositorio.ObterFilmesPorAtor(id).Result.Any())
            {
                Notificar("O ator possui filmes cadastrados");
                return false;
            }

            var ator = await _atorRepositorio.ObterPorId(id);
            if (ator is null)
            {
                Notificar("Ator não encontrado.");
                return false;
            }

            await _atorRepositorio.Remover(ator.Id);
            return true;
        }
    }
}