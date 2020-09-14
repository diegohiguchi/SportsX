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
   public class PessoaFisicaRepository : Repository<PessoaFisica>, IPessoaFisicaRepository
    {
        public PessoaFisicaRepository(ApplicationDbContext context) : base(context) { }

        public async Task<PessoaFisica> ObterPessoaFisicaPorId(Guid id)
        {
            return await Db.PessoaFisica.AsNoTracking().Include(p => p.Telefones).FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<PessoaFisica>> ListarTodos()
        {
            return await Db.PessoaFisica.AsNoTracking()
                .Include(p => p.Telefones)
                .ToListAsync();
        }
    }
}
