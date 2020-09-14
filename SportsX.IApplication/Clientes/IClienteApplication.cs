using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SportsX.Domain.Entities;

namespace SportsX.IApplication.Clientes
{
    public interface IClienteApplication
    {
        Task<IEnumerable<PessoaFisica>> ObterTodasPessoasFisicas();
        Task<IEnumerable<PessoaJuridica>> ObterTodasPessoasJuridicas();
    }
}
