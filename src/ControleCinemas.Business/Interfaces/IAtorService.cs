using System;
using System.Threading.Tasks;
using ControleCinemas.Business.Models;

namespace ControleCinemas.Business.Interfaces
{
    public interface IAtorService : IDisposable
    {
        Task<bool> Adicionar(Ator ator);
        Task<bool> Atualizar(Ator ator);
        Task<bool> Remover(Guid id);
    }
}