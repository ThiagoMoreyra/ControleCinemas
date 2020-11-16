using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ControleCinemas.Business.Interfaces;
using ControleCinemas.Business.Models;
using ControleCinemas.Data.Context;

namespace ControleCinemas.Data.Repository
{
    public class FilmeRepository : Repository<Filme>, IFilmeRepository
    {
        public FilmeRepository(CinemaDbContext db) : base(db)
        {
        }

        public async Task<IEnumerable<Cinema>> ObterCinemasPorFilme(Guid id)
        {
            var filme = await ObterPorId(id);
            return filme.Cinemas;
        }

        public async Task<Genero> ObterGeneroPorFilme(Guid id)
        {
            var filme = await ObterPorId(id);
            return filme.Genero;
        }

        public async Task<Ator> ObterAtorPorFilme(Guid id)
        {
            var filme = await ObterPorId(id);
            return filme.Ator;
        }
    }
}