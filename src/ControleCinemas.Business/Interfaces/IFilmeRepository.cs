using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ControleCinemas.Business.Models;

namespace ControleCinemas.Business.Interfaces
{
    public interface IFilmeRepository : IRepository<Filme>
    {
        Task<IEnumerable<Cinema>> ObterCinemasPorFilme(Guid id);
        Task<Genero> ObterGeneroPorFilme(Guid id);
        Task<Ator> ObterAtorPorFilme(Guid id);
    }

}