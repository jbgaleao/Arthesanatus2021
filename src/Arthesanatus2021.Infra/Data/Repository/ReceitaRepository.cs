using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

using Arthesanatus2021.Business.Models.Receitas;
using Arthesanatus2021.Business.Models.Revistas;
using Arthesanatus2021.Infra.Data.Context;

namespace Arthesanatus2021.Infra.Data.Repository
{
    public class ReceitaRepository : Repository<Receita>, IReceitaRepository
    {

        public ReceitaRepository(Arthes2021Context context) : base(context) { }


        public async Task<Receita> ObterReceitaInformacoes(Guid id)
        {
            return await Db.RECEITAS.AsNoTracking()
                .Include(f => f.InformacoesReceita)
                .FirstOrDefaultAsync(f => f.InformacoesReceita.Id == id);
        }

        public async Task<Receita> ObterRevistaReceitaInformacoes(Guid id)
        {
            return await Db.RECEITAS.AsNoTracking()
                .Include(f => f.InformacoesReceita)
                .Include(f => f.Revista)
                .FirstOrDefaultAsync(f => f.Id == id);
        }
    }
}
