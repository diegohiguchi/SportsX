using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SportsX.Domain.Entities;

namespace SportsX.Domain.Interfaces.Services
{
    public interface IPessoaFisicaService : IDisposable
    {
        Task<IEnumerable<PessoaFisica>> ObterTodos();
        Task Adicionar(PessoaFisica pessoFisca);
        Task Atualizar(PessoaFisica pessoFisca);
        Task Remover(Guid id);
        Task<PessoaFisica> ObterPorId(Guid id);
    }
}
