using System;
using System.Threading.Tasks;
using ControleCinemas.Business.Interfaces;
using ControleCinemas.Business.Models;
using ControleCinemas.Data.Context;

namespace ControleCinemas.Data.Repository
{
    public class IngressoRepository : Repository<Ingresso>, IIngressoRepository
    {
        public IngressoRepository(CinemaDbContext db) : base(db)
        {
        }

        public async Task<Cinema> ObterCinemaPorIngresso(Guid id)
        {
            var ingresso = await ObterPorId(id);
            return ingresso.Cinema;
        }
    }
}