using System;
using System.Threading.Tasks;
using ControleCinemas.Business.Interfaces;
using ControleCinemas.Business.Models;
using ControleCinemas.Business.Models.Validations;

namespace ControleCinemas.Business.Services
{
    public class EnderecoService : BaseService, IEnderecoService
    {
        public IEnderecoRepository _enderecoRepositorio { get; set; }
        public EnderecoService(INotificador notificador, IEnderecoRepository enderecoRepositorio) : base(notificador)
        {
            _enderecoRepositorio = enderecoRepositorio;
        }

        public async Task<bool> Adicionar(Endereco endereco)
        {
            if (!ExecutarValidacao(new EnderecoValidation(), endereco)) return false;

            await _enderecoRepositorio.Adicionar(endereco);
            return true;
        }

        public async Task<bool> Atualizar(Endereco endereco)
        {
            if (!ExecutarValidacao(new EnderecoValidation(), endereco)) return false;

            await _enderecoRepositorio.Atualizar(endereco);
            return true;
        }

        public void Dispose()
        {
            _enderecoRepositorio?.Dispose();
        }

        public async Task<bool> Remover(Guid id)
        {
            var cinema = _enderecoRepositorio.ObterCinemaPorEndereco(id);
            if (cinema is null)
            {
                Notificar("O endereço possui cinemas cadastrados");
                return false;
            }

            var endereco = await _enderecoRepositorio.ObterPorId(id);
            if (endereco is null)
            {
                Notificar("Endereço não encontrado.");
                return false;
            }

            await _enderecoRepositorio.Remover(endereco.Id);
            return true;
        }
    }
}