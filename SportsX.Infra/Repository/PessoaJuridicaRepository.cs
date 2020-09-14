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
   public class PessoaJuridicaRepository : Repository<PessoaJuridica>, IPessoaJuridicaRepository
    {
        public PessoaJuridicaRepository(ApplicationDbContext context) : base(context) { }

        public async Task<PessoaJuridica> ObterPessoaJuridicaPorId(Guid id)
        {
            return await Db.PessoaJuridica.AsNoTracking().Include(p => p.Telefones).FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<PessoaJuridica>> ListarTodos()
        {
            return await Db.PessoaJuridica.AsNoTracking()
                .Include(p => p.Telefones)
                .ToListAsync();
        }
    }
}
