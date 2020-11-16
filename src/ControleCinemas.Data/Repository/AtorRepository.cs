using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ControleCinemas.Business.Interfaces;
using ControleCinemas.Business.Models;
using ControleCinemas.Data.Context;

namespace ControleCinemas.Data.Repository
{
    public class AtorRepository : Repository<Ator>, IAtorRepository
    {
        public AtorRepository(CinemaDbContext db) : base(db)
        {
        }

        public async Task<IEnumerable<Filme>> ObterFilmesPorAtor(Guid id)
        {
            var ator = await ObterPorId(id);
            return ator.Filmes;
        }
    }
}