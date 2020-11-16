using System;
using System.Threading.Tasks;
using ControleCinemas.Business.Models;

namespace ControleCinemas.Business.Interfaces
{
    public interface IEnderecoRepository : IRepository<Endereco>
    {
        Task<Cinema> ObterCinemaPorEndereco(Guid id);
    }
}