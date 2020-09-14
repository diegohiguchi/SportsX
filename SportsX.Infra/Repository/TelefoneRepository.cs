using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SportsX.Domain.Entities;
using SportsX.Domain.Interfaces.Repositories;
using SportsX.Infra.Context;
using System.Linq;

namespace SportsX.Infra.Repository
{
   public class TelefoneRepository : Repository<Telefone>, ITelefoneRepository
    {
        public TelefoneRepository(ApplicationDbContext context) : base(context) { }

        public async Task<Telefone> ObterTelefone(Guid id)
        {
            return await Db.Telefone.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<Telefone>> ListarTodos()
        {
            return await Db.Telefone.AsNoTracking()
                .ToListAsync();
        }
    }
}
