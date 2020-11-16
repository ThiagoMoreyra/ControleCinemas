using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ControleCinemas.Business.Models;

namespace ControleCinemas.Business.Interfaces
{
    public interface IGeneroRepository : IRepository<Genero>
    {
        Task<IEnumerable<Filme>> ObterFilmesPorGenero(Guid id);
    }
}