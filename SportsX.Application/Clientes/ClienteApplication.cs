using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportsX.Domain.Entities;
using SportsX.Domain.Interfaces;
using SportsX.Domain.Interfaces.Services;
using SportsX.Domain.Services;
using SportsX.IApplication.Clientes;

namespace SportsX.Application.Clientes
{
    public class ClienteApplication : BaseService, IClienteApplication
    {
        private readonly IPessoaFisicaService _pessoaFisicaService;
        private readonly IPessoaJuridicaService _pessoaJuridicaService;
        public ClienteApplication(
            IPessoaFisicaService pessoaFisicaService,
            ITelefoneService telefoneService,
            INotificador notificador, IPessoaJuridicaService pessoaJuridicaService) : base(notificador)
        {
            _pessoaFisicaService = pessoaFisicaService;
            _pessoaJuridicaService = pessoaJuridicaService;
        }

        public async Task<IEnumerable<PessoaFisica>> ObterTodasPessoasFisicas()
        {
            return await _pessoaFisicaService.ObterTodos();
        }

        public async Task<IEnumerable<PessoaJuridica>> ObterTodasPessoasJuridicas()
        {
            return await _pessoaJuridicaService.ObterTodos();
        }
    }
}
