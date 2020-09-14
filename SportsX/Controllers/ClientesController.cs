using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SportsX.Domain.Entities;
using SportsX.Domain.Interfaces;
using SportsX.IApplication.Clientes;
using SportsX.ViewModels;

namespace SportsX.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : MainController
    {

        private readonly IClienteApplication _clienteApplication;
        private readonly IMapper _mapper;

        public ClientesController(
            IClienteApplication clienteApplication,
            INotificador notificador, 
            IMapper mapper) : base(notificador)
        {
            _clienteApplication = clienteApplication;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<ClienteViewModel>> ObterTodos()
        {
            var listaPessoaFisica = _mapper.Map<IEnumerable<ClienteViewModel>>(await _clienteApplication.ObterTodasPessoasFisicas());
            var listaPessoaJuridica = _mapper.Map<IEnumerable<ClienteViewModel>>(await _clienteApplication.ObterTodasPessoasJuridicas());
            var listaCliente = new List<ClienteViewModel>();

            listaCliente.AddRange(listaPessoaFisica);
            listaCliente.AddRange(listaPessoaJuridica);

            return listaCliente.OrderBy(x => x.Nome);
        }

    }
}
