using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SportsX.Domain.Entities;

namespace SportsX.Domain.Interfaces.Repositories
{
    public interface IPessoaJuridicaRepository : IRepository<PessoaJuridica>
    {
        Task<IEnumerable<PessoaJuridica>> ListarTodos();
        Task<PessoaJuridica> ObterPessoaJuridicaPorId(Guid id);
    }
}
