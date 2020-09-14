using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SportsX.Domain.Entities;

namespace SportsX.Domain.Interfaces.Repositories
{
    public interface IPessoaFisicaRepository : IRepository<PessoaFisica>
    {
        Task<IEnumerable<PessoaFisica>> ListarTodos();
        Task<PessoaFisica> ObterPessoaFisicaPorId(Guid id);
    }
}
