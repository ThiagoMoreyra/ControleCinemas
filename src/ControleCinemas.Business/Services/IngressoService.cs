using System;
using System.Linq;
using System.Threading.Tasks;
using ControleCinemas.Business.Interfaces;
using ControleCinemas.Business.Models;
using ControleCinemas.Business.Models.Validations;

namespace ControleCinemas.Business.Services
{
    public class IngressoService : BaseService, IIngressoService
    {
        public IIngressoRepository _ingressoRepositorio { get; set; }
        public IngressoService(INotificador notificador, IIngressoRepository ingressoRepositorio) : base(notificador)
        {
            _ingressoRepositorio = ingressoRepositorio;
        }

        public async Task<bool> Adicionar(Ingresso ingresso)
        {
            if (!ExecutarValidacao(new IngressoValidation(), ingresso)) return false;

            if (_ingressoRepositorio.Buscar(f => f.Id == ingresso.Id).Result.Any())
            {
                Notificar("Já existe um ingresso com este id");
                return false;
            }

            await _ingressoRepositorio.Adicionar(ingresso);
            return true;
        }

        public async Task<bool> Atualizar(Ingresso ingresso)
        {
            if (!ExecutarValidacao(new IngressoValidation(), ingresso)) return false;

            if (!_ingressoRepositorio.Buscar(f => f.Id == ingresso.Id).Result.Any())
            {
                Notificar("Já existe um ingresso com este id");
                return false;
            }

            await _ingressoRepositorio.Atualizar(ingresso);
            return true;
        }

        public void Dispose()
        {
            _ingressoRepositorio?.Dispose();
        }
        public async Task<bool> Remover(Guid id)
        {
            var cinema = _ingressoRepositorio.ObterCinemaPorIngresso(id);
            if (cinema is null)
            {
                Notificar("O ingresso possui cinemas cadastrados");
                return false;
            }

            var ingresso = await _ingressoRepositorio.ObterPorId(id);
            if (ingresso is null)
            {
                Notificar("Ingresso não encontrado.");
                return false;
            }

            await _ingressoRepositorio.Remover(ingresso.Id);
            return true;
        }
    }
}