using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SportsX.Domain.Entities;
using SportsX.Domain.Interfaces;
using SportsX.Domain.Interfaces.Services;
using SportsX.Domain.Services;
using SportsX.IApplication.PessoasJuridicas;

namespace SportsX.Application.PessoasJuridicas
{
    public class PessoaJuridicaApplication : BaseService, IPessoaJuridicaApplication
    {
        private readonly IPessoaJuridicaService _pessoaFisicaService;
        private readonly ITelefoneService _telefoneService;
        public PessoaJuridicaApplication(
            IPessoaJuridicaService pessoaFisicaService,
            ITelefoneService telefoneService,
            INotificador notificador) : base(notificador)
        {
            _pessoaFisicaService = pessoaFisicaService;
            _telefoneService = telefoneService;
        }

        public async Task<IEnumerable<PessoaJuridica>> ObterTodos()
        {
            return await _pessoaFisicaService.ObterTodos();
        }

        public async Task<PessoaJuridica> ObterPessoaJuridicaPorId(Guid id)
        {
            return await _pessoaFisicaService.ObterPorId(id);
        }

        public async Task Adicionar(PessoaJuridica pessoaFisica)
        {
            if (_pessoaFisicaService.ObterPorId(pessoaFisica.Id).Result != null)
            {
                Notificar("Já existe cliente com esse id.");
                return;
            }

            var clientePessoaJuridica = new PessoaJuridica(
                pessoaFisica.RazaoSocial,
                pessoaFisica.Cnpj,
                pessoaFisica.Nome,
                pessoaFisica.Email,
                pessoaFisica.Cep,
                pessoaFisica.Classificacao
            );

            foreach (var telefone in pessoaFisica.Telefones)
                clientePessoaJuridica.AdicionarTelefone(telefone);

            await _pessoaFisicaService.Adicionar(clientePessoaJuridica);
        }

        public async Task Atualizar(Guid id, PessoaJuridica pessoaFisica)
        {
            var clientePessoaJuridica = _pessoaFisicaService.ObterPorId(id).Result;

            if (clientePessoaJuridica == null)
            {
                Notificar("Cliente não encontrado.");
                return;
            }
           
            clientePessoaJuridica.AlterarRazaoSocial(pessoaFisica.RazaoSocial);
            clientePessoaJuridica.AlterarCnpj(pessoaFisica.Cnpj);
            clientePessoaJuridica.AlterarNome(pessoaFisica.Nome);
            clientePessoaJuridica.AlterarEmail(pessoaFisica.Email);
            clientePessoaJuridica.AlterarCep(pessoaFisica.Cep);
            clientePessoaJuridica.AlterarClassificacao(pessoaFisica.Classificacao);

            foreach (var telefoneAtual in clientePessoaJuridica.Telefones)
                await _telefoneService.Remover(telefoneAtual.Id);

            clientePessoaJuridica.AtualizarTelefone(pessoaFisica.Telefones);

            await _pessoaFisicaService.Atualizar(clientePessoaJuridica);
        }

        public async Task Remover(Guid id)
        {
            var clientePessoaJuridica = _pessoaFisicaService.ObterPorId(id).Result;

            if (clientePessoaJuridica == null)
            {
                Notificar("Cliente não encontrado.");
                return;
            }

            foreach (var telefoneAtual in clientePessoaJuridica.Telefones)
                await _telefoneService.Remover(telefoneAtual.Id);

            await _pessoaFisicaService.Remover(id);
        }
    }
}
