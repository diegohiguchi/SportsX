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
    public class PessoaJuridicaService : IPessoaJuridicaService
    {
        private readonly IPessoaJuridicaRepository _pessoaJuridicaRepository;

        public PessoaJuridicaService(IPessoaJuridicaRepository pessoaJuridicaRepository)
        {
            _pessoaJuridicaRepository = pessoaJuridicaRepository;
        }
       
        public async Task<IEnumerable<PessoaJuridica>> ObterTodos()
        {
            return await _pessoaJuridicaRepository.ListarTodos();
        }

        public async Task Adicionar(PessoaJuridica pessoaFisca)
        {
            await _pessoaJuridicaRepository.Adicionar(pessoaFisca);
        }

        public async Task Atualizar(PessoaJuridica pessoaFisca)
        {
            await _pessoaJuridicaRepository.Atualizar(pessoaFisca);
        }

        public async Task Remover(Guid id)
        {
            await _pessoaJuridicaRepository.Remover(id);
        }

        public async Task<PessoaJuridica> ObterPorId(Guid id)
        {
            return _pessoaJuridicaRepository.ObterPessoaJuridicaPorId(id).Result;
        }

        public void Dispose()
        {
            _pessoaJuridicaRepository?.Dispose();
        }
    }
}
