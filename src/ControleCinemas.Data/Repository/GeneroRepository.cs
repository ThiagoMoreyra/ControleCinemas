using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ControleCinemas.Business.Interfaces;
using ControleCinemas.Business.Models;
using ControleCinemas.Data.Context;

namespace ControleCinemas.Data.Repository
{
    public class GeneroRepository : Repository<Genero>, IGeneroRepository
    {
        public GeneroRepository(CinemaDbContext db) : base(db)
        {
        }

        public async Task<IEnumerable<Filme>> ObterFilmesPorGenero(Guid id)
        {
            var genero = await ObterPorId(id);
            return genero.Filmes;
        }
    }
}