using System;
using System.Threading.Tasks;
using ControleCinemas.Business.Models;

namespace ControleCinemas.Business.Interfaces
{
    public interface ISessaoService : IDisposable
    {
        Task<bool> Adicionar(Sessao sessao);
        Task<bool> Atualizar(Sessao sessao);
        Task<bool> Remover(Guid id);
    }
}