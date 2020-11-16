using System;
using System.Threading.Tasks;
using ControleCinemas.Business.Interfaces;
using ControleCinemas.Business.Models;
using ControleCinemas.Data.Context;

namespace ControleCinemas.Data.Repository
{
    public class EnderecoRepository : Repository<Endereco>, IEnderecoRepository
    {
        public EnderecoRepository(CinemaDbContext db) : base(db)
        {
        }

        public async Task<Cinema> ObterCinemaPorEndereco(Guid id)
        {
            var endereco = await ObterPorId(id);
            return endereco.Cinema;
        }
    }
}