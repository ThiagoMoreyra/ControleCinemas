using System;
using System.Linq;
using System.Threading.Tasks;
using ControleCinemas.Business.Interfaces;
using ControleCinemas.Business.Models;
using ControleCinemas.Business.Models.Validations;

namespace ControleCinemas.Business.Services
{
    public class CinemaService : BaseService, ICinemaService
    {
        public ICinemaRepository _cinemaRepositorio { get; set; }
        public CinemaService(INotificador notificador, ICinemaRepository cinemaRepositorio) : base(notificador)
        {
            _cinemaRepositorio = cinemaRepositorio;
        }

        public async Task<bool> Adicionar(Cinema cinema)
        {
            if (!ExecutarValidacao(new CinemaValidation(), cinema)) return false;

            if (_cinemaRepositorio.Buscar(f => f.NomeEmpresa == cinema.NomeEmpresa).Result.Any())
            {
                Notificar("Já existe um cinema com este nome");
                return false;
            }

            await _cinemaRepositorio.Adicionar(cinema);
            return true;
        }

        public async Task<bool> Atualizar(Cinema cinema)
        {
            if (!ExecutarValidacao(new CinemaValidation(), cinema)) return false;

            if (!_cinemaRepositorio.Buscar(f => f.NomeEmpresa == cinema.NomeEmpresa && f.Id == cinema.Id).Result.Any())
            {
                Notificar("Não existe um cinema com este nome");
                return false;
            }

            await _cinemaRepositorio.Atualizar(cinema);
            return true;
        }

        public void Dispose()
        {
            _cinemaRepositorio?.Dispose();
        }

        public async Task<bool> Remover(Guid id)
        {
            if (_cinemaRepositorio.ObterFilmesPorCinema(id).Result.Any())
            {
                Notificar("O cinema possui filmes cadastrados");
                return false;
            }

            if (_cinemaRepositorio.ObterSessoesPorCinema(id).Result.Any())
            {
                Notificar("O cinema possui sessões cadastradas");
                return false;
            }

            var cinema = await _cinemaRepositorio.ObterPorId(id);
            if (cinema is null)
            {
                Notificar("Cinema não encontrado.");
                return false;
            }

            await _cinemaRepositorio.Remover(cinema.Id);
            return true;
        }
    }
}