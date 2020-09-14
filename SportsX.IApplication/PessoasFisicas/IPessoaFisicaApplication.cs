using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SportsX.Domain.Entities;

namespace SportsX.IApplication.PessoasFisicas
{
    public interface IPessoaFisicaApplication
    {
        Task<IEnumerable<PessoaFisica>> ObterTodos();
        Task<PessoaFisica> ObterPessoaFisicaPorId(Guid id);
        Task Adicionar(PessoaFisica pessoaFisica);
        Task Atualizar(Guid id, PessoaFisica pessoaFisica);
        Task Remover(Guid id);
    }
}
