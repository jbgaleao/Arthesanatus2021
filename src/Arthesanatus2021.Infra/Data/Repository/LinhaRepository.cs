using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

using Arthesanatus2021.Business.Models.Linhas;
using Arthesanatus2021.Business.Models.Cores;
using Arthesanatus2021.Business.Models.Estoques;
using Arthesanatus2021.Infra.Data.Context;

namespace Arthesanatus2021.Infra.Data.Repository
{
    public class LinhaRepository : Repository<Linha>, ILinhaRepository
    {
        public LinhaRepository(Arthesanatus2021Context context) : base(context) { }

        public async Task<IEnumerable<Linha>> ObterLinhasCorEstoque(Guid linhaId)
        {
            return await Db.LINHAS
                 .AsNoTracking()
                 .Include(c => c.ListaCores)
                 .Include(e => e.ListaEstoques)
                 .Where(l => l.Id == linhaId)
                 .ToListAsync();
        }
    }
}
