using System;
using System.Threading.Tasks;
using ControleCinemas.Business.Models;

namespace ControleCinemas.Business.Interfaces
{
    public interface IGeneroService : IDisposable
    {
        Task<bool> Adicionar(Genero genero);
        Task<bool> Atualizar(Genero genero);
        Task<bool> Remover(Guid id);
    }
}