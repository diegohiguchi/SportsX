using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SportsX.Domain.Entities;

namespace SportsX.IApplication.PessoasJuridicas
{
    public interface IPessoaJuridicaApplication
    {
        Task<IEnumerable<PessoaJuridica>> ObterTodos();
        Task<PessoaJuridica> ObterPessoaJuridicaPorId(Guid id);
        Task Adicionar(PessoaJuridica pessoaFisica);
        Task Atualizar(Guid id, PessoaJuridica pessoaFisica);
        Task Remover(Guid id);
    }
}
