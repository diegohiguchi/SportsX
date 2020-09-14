using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SportsX.Domain.Entities;

namespace SportsX.Domain.Interfaces.Services
{
    public interface ITelefoneService : IDisposable
    {
        Task<IEnumerable<Telefone>> ObterTodos();
        Task<Telefone> ObterPorId(Guid id);
        Task Remover(Guid id);
    }
}
