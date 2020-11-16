using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ControleCinemas.Business.Models;

namespace ControleCinemas.Business.Interfaces
{
    public interface ICinemaRepository : IRepository<Cinema>
    {
        Task<IEnumerable<Filme>> ObterFilmesPorCinema(Guid id);
        Task<IEnumerable<Sessao>> ObterSessoesPorCinema(Guid id);
    }
}