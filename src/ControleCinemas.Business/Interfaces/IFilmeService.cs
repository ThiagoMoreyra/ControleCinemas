using System;
using System.Threading.Tasks;
using ControleCinemas.Business.Models;

namespace ControleCinemas.Business.Interfaces
{
    public interface IFilmeService : IDisposable
    {
        Task<bool> Adicionar(Filme filme);
        Task<bool> Atualizar(Filme filme);
        Task<bool> Remover(Guid id);
    }
}