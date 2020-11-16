using System;
using System.Threading.Tasks;
using ControleCinemas.Business.Models;

namespace ControleCinemas.Business.Interfaces
{
    public interface ISessaoRepository : IRepository<Sessao>
    {
        Task<Cinema> ObterCinemaPorIngresso(Guid id);
    }
}