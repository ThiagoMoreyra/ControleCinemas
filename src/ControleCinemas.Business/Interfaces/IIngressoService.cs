using System;
using System.Threading.Tasks;
using ControleCinemas.Business.Models;

namespace ControleCinemas.Business.Interfaces
{
    public interface IIngressoService : IDisposable
    {
        Task<bool> Adicionar(Ingresso ingresso);
        Task<bool> Atualizar(Ingresso ingresso);
        Task<bool> Remover(Guid id);
    }
}