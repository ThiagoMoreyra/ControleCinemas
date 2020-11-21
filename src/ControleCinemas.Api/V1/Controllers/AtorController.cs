using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ControleCinemas.Api.Controllers;
using ControleCinemas.Api.ViewModels;
using ControleCinemas.Business.Interfaces;
using ControleCinemas.Business.Models;
using Microsoft.AspNetCore.Mvc;

namespace ControleCinemas.Api.V1.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v1/atores")]
    public class AtorController : MainController
    {
        private readonly IAtorRepository _atorRepository;
        private readonly IAtorService _atorService;
        private readonly IMapper _mapper;
        public AtorController(IAtorRepository atorRepository,
                             IAtorService atorService,
                             IMapper mapper,
                             INotificador notificador) : base(notificador)
        {
            _atorRepository = atorRepository;
            _atorService = atorService;
            _mapper = mapper;
        }

        [HttpGet("")]
        public async Task<IEnumerable<AtorViewModel>> ObterTodos()
        {
            return _mapper.Map<IEnumerable<AtorViewModel>>(await _atorRepository.ObterTodos());
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<AtorViewModel>> ObterPorId(Guid id)
        {
            var ator = await _atorRepository.ObterPorId(id);

            if (ator == null) return NotFound();

            return _mapper.Map<AtorViewModel>(ator);
        }

        [HttpPost("")]
        public async Task<ActionResult<AtorViewModel>> Adicionar([FromBody] AtorViewModel atorViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _atorService.Adicionar(_mapper.Map<Ator>(atorViewModel));

            return CustomResponse(atorViewModel);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<AtorViewModel>> Atualizar(Guid id, [FromBody] AtorViewModel atorViewModel)
        {
            if (id != atorViewModel.Id)
            {
                NotificarErro("O id informado não é o mesmo que foi passado na query");
                return CustomResponse(atorViewModel);
            }

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _atorService.Atualizar(_mapper.Map<Ator>(atorViewModel));

            return CustomResponse(atorViewModel);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<AtorViewModel>> Excluir(Guid id)
        {
            var atorViewModel = _mapper.Map<AtorViewModel>(await _atorRepository.ObterPorId(id));

            if (atorViewModel == null) return NotFound();

            await _atorService.Remover(atorViewModel.Id);

            return CustomResponse(atorViewModel);
        }
    }
}