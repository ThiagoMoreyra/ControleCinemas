using System;
using System.Threading.Tasks;
using ControleCinemas.Business.Models;

namespace ControleCinemas.Business.Interfaces
{
    public interface IIngressoRepository : IRepository<Ingresso>
    {
        Task<Cinema> ObterCinemaPorIngresso(Guid id);
    }
}