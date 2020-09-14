using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SportsX.Domain.Entities;

namespace SportsX.Domain.Interfaces.Services
{
    public interface IPessoaJuridicaService : IDisposable
    {
        Task<IEnumerable<PessoaJuridica>> ObterTodos();
        Task Adicionar(PessoaJuridica pessoFisca);
        Task Atualizar(PessoaJuridica pessoFisca);
        Task Remover(Guid id);
        Task<PessoaJuridica> ObterPorId(Guid id);
    }
}
