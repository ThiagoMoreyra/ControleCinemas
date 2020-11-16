using System;
using System.Threading.Tasks;
using ControleCinemas.Business.Interfaces;
using ControleCinemas.Business.Models;
using ControleCinemas.Data.Context;

namespace ControleCinemas.Data.Repository
{
    public class SessaoRepository : Repository<Sessao>, ISessaoRepository
    {
        public SessaoRepository(CinemaDbContext db) : base(db)
        {
        }

        public async Task<Cinema> ObterCinemaPorIngresso(Guid id)
        {
            var sessao = await ObterPorId(id);
            return sessao.Cinema;
        }
    }
}