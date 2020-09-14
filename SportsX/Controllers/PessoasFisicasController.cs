using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SportsX.Domain.Entities;
using SportsX.Domain.Interfaces;
using SportsX.IApplication.PessoasFisicas;
using SportsX.ViewModels;

namespace SportsX.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoasFisicasController : MainController
    {

        private readonly IPessoaFisicaApplication _pessoaFisicaApplication;
        private readonly IMapper _mapper;

        public PessoasFisicasController(
            IPessoaFisicaApplication pessoaFisicaApplication,
            INotificador notificador, 
            IMapper mapper) : base(notificador)
        {
            _pessoaFisicaApplication = pessoaFisicaApplication;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<PessoaFisicaViewModel>> ObterTodos()
        {
            return _mapper.Map<IEnumerable<PessoaFisicaViewModel>>(await _pessoaFisicaApplication.ObterTodos()).OrderBy(x => x.Nome);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<PessoaFisicaViewModel>> ObterPorId(Guid id)
        {
            var pessoaFisica = _mapper.Map<PessoaFisicaViewModel>(await _pessoaFisicaApplication.ObterPessoaFisicaPorId(id));

            if (pessoaFisica == null) return NotFound();

            return pessoaFisica;
        }


        [HttpPost]
        public async Task<ActionResult<PessoaFisicaViewModel>> Adicionar(PessoaFisicaViewModel pessoaFisicaViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _pessoaFisicaApplication.Adicionar(_mapper.Map<PessoaFisica>(pessoaFisicaViewModel));

            return CustomResponse(pessoaFisicaViewModel);
        }


        [HttpPut("{id:guid}")]
        public async Task<ActionResult<PessoaFisicaViewModel>> Atualizar(Guid id, PessoaFisicaViewModel pessoaFisicaViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _pessoaFisicaApplication.Atualizar(id, _mapper.Map<PessoaFisica>(pessoaFisicaViewModel));

            return CustomResponse(pessoaFisicaViewModel);
        }


        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> Excluir(Guid id)
        {
            await _pessoaFisicaApplication.Remover(id);

            return CustomResponse();
        }
    }
}
