using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SportsX.Domain.Entities;
using SportsX.Domain.Interfaces;
using SportsX.Domain.Interfaces.Services;
using SportsX.Domain.Services;
using SportsX.IApplication.PessoasFisicas;

namespace SportsX.Application.PessoasFisicas
{
    public class PessoaFisicaApplication : BaseService, IPessoaFisicaApplication
    {
        private readonly IPessoaFisicaService _pessoaFisicaService;
        private readonly ITelefoneService _telefoneService;
        public PessoaFisicaApplication(
            IPessoaFisicaService pessoaFisicaService,
            ITelefoneService telefoneService,
            INotificador notificador) : base(notificador)
        {
            _pessoaFisicaService = pessoaFisicaService;
            _telefoneService = telefoneService;
        }

        public async Task<IEnumerable<PessoaFisica>> ObterTodos()
        {
            return await _pessoaFisicaService.ObterTodos();
        }

        public async Task<PessoaFisica> ObterPessoaFisicaPorId(Guid id)
        {
            return await _pessoaFisicaService.ObterPorId(id);
        }

        public async Task Adicionar(PessoaFisica pessoaFisica)
        {
            if (_pessoaFisicaService.ObterPorId(pessoaFisica.Id).Result != null)
            {
                Notificar("Já existe cliente com esse id.");
                return;
            }

            var clientePessoaFisica = new PessoaFisica(
                pessoaFisica.Cpf,
                pessoaFisica.Nome,
                pessoaFisica.Email,
                pessoaFisica.Cep,
                pessoaFisica.Classificacao
            );

            foreach (var telefone in pessoaFisica.Telefones)
                clientePessoaFisica.AdicionarTelefone(telefone);

            await _pessoaFisicaService.Adicionar(clientePessoaFisica);
        }

        public async Task Atualizar(Guid id, PessoaFisica pessoaFisica)
        {
            var clientePessoaFisica = _pessoaFisicaService.ObterPorId(id).Result;

            if (clientePessoaFisica == null)
            {
                Notificar("Cliente não encontrado.");
                return;
            }
           
            clientePessoaFisica.AlterarCpf(pessoaFisica.Cpf);
            clientePessoaFisica.AlterarNome(pessoaFisica.Nome);
            clientePessoaFisica.AlterarEmail(pessoaFisica.Email);
            clientePessoaFisica.AlterarCep(pessoaFisica.Cep);
            clientePessoaFisica.AlterarClassificacao(pessoaFisica.Classificacao);

            foreach (var telefoneAtual in clientePessoaFisica.Telefones)
                await _telefoneService.Remover(telefoneAtual.Id);

            clientePessoaFisica.AtualizarTelefone(pessoaFisica.Telefones);

            await _pessoaFisicaService.Atualizar(clientePessoaFisica);
        }

        public async Task Remover(Guid id)
        {
            var clientePessoaFisica = _pessoaFisicaService.ObterPorId(id).Result;

            if (clientePessoaFisica == null)
            {
                Notificar("Cliente não encontrado.");
                return;
            }

            foreach (var telefoneAtual in clientePessoaFisica.Telefones)
                await _telefoneService.Remover(telefoneAtual.Id);

            await _pessoaFisicaService.Remover(id);
        }
    }
}
