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
    public class TelefoneService : ITelefoneService
    {
        private readonly ITelefoneRepository _telefoneRepository;

        public TelefoneService(ITelefoneRepository telefoneRepository)
        {
            _telefoneRepository = telefoneRepository;
        }
       
        public async Task<IEnumerable<Telefone>> ObterTodos()
        {
            return await _telefoneRepository.ListarTodos();
        }

        public async Task<Telefone> ObterPorId(Guid id)
        {
            return _telefoneRepository.Buscar(c => c.Id == id).Result.FirstOrDefault();
        }

        public async Task Remover(Guid id)
        {
            await _telefoneRepository.Remover(id);
        }
        public void Dispose()
        {
            _telefoneRepository?.Dispose();
        }
    }
}
