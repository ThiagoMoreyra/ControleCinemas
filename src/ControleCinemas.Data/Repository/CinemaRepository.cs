using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ControleCinemas.Business.Interfaces;
using ControleCinemas.Business.Models;
using ControleCinemas.Data.Context;

namespace ControleCinemas.Data.Repository
{
    public class CinemaRepository : Repository<Cinema>, ICinemaRepository
    {
        public CinemaRepository(CinemaDbContext db) : base(db)
        {
        }

        public async Task<IEnumerable<Filme>> ObterFilmesPorCinema(Guid id)
        {
            var cinema = await ObterPorId(id);
            return cinema.Filmes;
        }

        public async Task<IEnumerable<Sessao>> ObterSessoesPorCinema(Guid id)
        {
            var cinema = await ObterPorId(id);
            return cinema.Sessoes;
        }
    }
}