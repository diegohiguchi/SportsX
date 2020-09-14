using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SportsX.Domain.Entities;
using SportsX.Domain.Interfaces;
using SportsX.IApplication.PessoasFisicas;
using SportsX.IApplication.PessoasJuridicas;
using SportsX.ViewModels;

namespace SportsX.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoasJuridicasController : MainController
    {

        private readonly IPessoaJuridicaApplication _pessoaJuridicaApplication;
        private readonly IMapper _mapper;

        public PessoasJuridicasController(
            IPessoaJuridicaApplication pessoaJuridicaApplication,
            INotificador notificador, 
            IMapper mapper) : base(notificador)
        {
            _pessoaJuridicaApplication = pessoaJuridicaApplication;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<PessoaJuridicaViewModel>> ObterTodos()
        {
            return _mapper.Map<IEnumerable<PessoaJuridicaViewModel>>(await _pessoaJuridicaApplication.ObterTodos()).OrderBy(x=> x.Nome);
        }


        [HttpGet("{id:guid}")]
        public async Task<ActionResult<PessoaJuridicaViewModel>> ObterPorId(Guid id)
        {
            var pessoaFisica = _mapper.Map<PessoaJuridicaViewModel>(await _pessoaJuridicaApplication.ObterPessoaJuridicaPorId(id));

            if (pessoaFisica == null) return NotFound();

            return pessoaFisica;
        }


        [HttpPost]
        public async Task<ActionResult<PessoaJuridicaViewModel>> Adicionar(PessoaJuridicaViewModel pessoaFisicaViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _pessoaJuridicaApplication.Adicionar(_mapper.Map<PessoaJuridica>(pessoaFisicaViewModel));

            return CustomResponse(pessoaFisicaViewModel);
        }


        [HttpPut("{id:guid}")]
        public async Task<ActionResult<PessoaJuridicaViewModel>> Atualizar(Guid id, PessoaJuridicaViewModel pessoaFisicaViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _pessoaJuridicaApplication.Atualizar(id, _mapper.Map<PessoaJuridica>(pessoaFisicaViewModel));

            return CustomResponse(pessoaFisicaViewModel);
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> Excluir(Guid id)
        {
            await _pessoaJuridicaApplication.Remover(id);

            return CustomResponse();
        }
    }
}
