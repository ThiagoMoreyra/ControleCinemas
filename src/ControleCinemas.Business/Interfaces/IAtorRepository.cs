using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ControleCinemas.Business.Models;

namespace ControleCinemas.Business.Interfaces
{
    public interface IAtorRepository : IRepository<Ator>
    {
        Task<IEnumerable<Filme>> ObterFilmesPorAtor(Guid id);
    }
}