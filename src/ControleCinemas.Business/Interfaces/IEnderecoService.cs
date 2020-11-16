using System;
using System.Threading.Tasks;
using ControleCinemas.Business.Models;

namespace ControleCinemas.Business.Interfaces
{
    public interface IEnderecoService : IDisposable
    {
        Task<bool> Adicionar(Endereco endereco);
        Task<bool> Atualizar(Endereco endereco);
        Task<bool> Remover(Guid id);
    }
}