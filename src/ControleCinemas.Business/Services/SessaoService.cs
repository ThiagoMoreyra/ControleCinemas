using System;
using System.Linq;
using System.Threading.Tasks;
using ControleCinemas.Business.Interfaces;
using ControleCinemas.Business.Models;
using ControleCinemas.Business.Models.Validations;

namespace ControleCinemas.Business.Services
{
    public class SessaoService : BaseService, ISessaoService
    {
        public ISessaoRepository _sessaoRepository { get; set; }
        public SessaoService(INotificador notificador, ISessaoRepository sessaoRepository) : base(notificador)
        {
            _sessaoRepository = sessaoRepository;
        }

        public async Task<bool> Adicionar(Sessao sessao)
        {
            if (!ExecutarValidacao(new SessaoValidation(), sessao)) return false;

            if (_sessaoRepository.Buscar(f => f.Id == sessao.Id).Result.Any())
            {
                Notificar("Já existe uma sessão com este id");
                return false;
            }

            await _sessaoRepository.Adicionar(sessao);
            return true;
        }

        public async Task<bool> Atualizar(Sessao sessao)
        {
            if (!ExecutarValidacao(new SessaoValidation(), sessao)) return false;

            if (!_sessaoRepository.Buscar(f => f.Id == sessao.Id).Result.Any())
            {
                Notificar("Já existe um ingresso com este id");
                return false;
            }

            await _sessaoRepository.Atualizar(sessao);
            return true;
        }

        public void Dispose()
        {
            _sessaoRepository?.Dispose();
        }

        public async Task<bool> Remover(Guid id)
        {
            var cinema = _sessaoRepository.ObterCinemaPorIngresso(id);
            if (cinema is null)
            {
                Notificar("O ingresso possui cinemas cadastrados");
                return false;
            }

            var sessao = await _sessaoRepository.ObterPorId(id);
            if (sessao is null)
            {
                Notificar("Sessão não encontrada.");
                return false;
            }

            await _sessaoRepository.Remover(sessao.Id);
            return true;
        }
    }
}