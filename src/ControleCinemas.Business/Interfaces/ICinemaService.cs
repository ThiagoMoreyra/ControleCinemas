using System;
using System.Threading.Tasks;
using ControleCinemas.Business.Models;

namespace ControleCinemas.Business.Interfaces
{
    public interface ICinemaService : IDisposable
    {
        Task<bool> Adicionar(Cinema cinema);
        Task<bool> Atualizar(Cinema cinema);
        Task<bool> Remover(Guid id);
    }
}