using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportsX.Domain.Entities;
using SportsX.Domain.Interfaces.Repositories;
using SportsX.Domain.Interfaces.Services;

namespace SportsX.Domain.Services
{
    public class PessoaFisicaService : IPessoaFisicaService
    {
        private readonly IPessoaFisicaRepository _pessoaFisicaRepository;

        public PessoaFisicaService(IPessoaFisicaRepository pessoaFisicaRepository)
        {
            _pessoaFisicaRepository = pessoaFisicaRepository;
        }
       
        public async Task<IEnumerable<PessoaFisica>> ObterTodos()
        {
            return await _pessoaFisicaRepository.ListarTodos();
        }

        public async Task Adicionar(PessoaFisica pessoaFisca)
        {
            await _pessoaFisicaRepository.Adicionar(pessoaFisca);
        }

        public async Task Atualizar(PessoaFisica pessoaFisca)
        {
            await _pessoaFisicaRepository.Atualizar(pessoaFisca);
        }

        public async Task Remover(Guid id)
        {
            await _pessoaFisicaRepository.Remover(id);
        }

        public async Task<PessoaFisica> ObterPorId(Guid id)
        {
            return _pessoaFisicaRepository.ObterPessoaFisicaPorId(id).Result;
        }

        public void Dispose()
        {
            _pessoaFisicaRepository?.Dispose();
        }
    }
}
