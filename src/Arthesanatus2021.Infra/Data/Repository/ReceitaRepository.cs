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
        public ReceitaRepository(Arthesanatus2021Context context) : base(context) { }

        public async Task<Receita> ObterReceitaRevista(Guid id)
        {
            return await Db.RECEITAS
                .AsNoTracking()
                .Include(r => r.Revista)
                .FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<IEnumerable<Receita>> ObterReceitasDaRevista(Guid id)
        {
            return await Db.RECEITAS
                 .AsNoTracking()
                 .Include(r => r.Revista)
                 .Where(r => r.Revista.Id == id)
                 .ToListAsync();
        }

        public async Task<IEnumerable<Receita>> ObterReceitasPorRevistaAnoEdicao(int ano)
        {
            return await Db.RECEITAS
                .AsNoTracking()
                .Include(r => r.Revista)
                .Where(r => r.Revista.AnoEdicao == ano)
                .ToListAsync();
        }

        public async Task<IEnumerable<Receita>> ObterReceitasPorRevistaMesEdicao(Mes mes)
        {
            return await Db.RECEITAS
                .AsNoTracking()
                .Include(r => r.Revista)
                .Where(r => r.Revista.MesEdicao == mes)
                .ToListAsync();
        }

        public async Task<IEnumerable<Receita>> ObterReceitasPorRevistaMesEdicaoAnoEdicao(Mes mes, int ano)
        {
            return await Db.RECEITAS
                .AsNoTracking()
                .Include(r => r.Revista)
                .Where(r => r.Revista.MesEdicao == mes && r.Revista.AnoEdicao == ano)
                .ToListAsync();
        }

        public async Task<IEnumerable<Receita>> ObterReceitasPorRevistaNumEdicao(int numEdicao)
        {
            return await Db.RECEITAS
                .AsNoTracking()
                .Include(r => r.Revista)
                .Where(r => r.Revista.NumeroEdicao == numEdicao)
                .ToListAsync();
        }

        public async Task<IEnumerable<Receita>> ObterReceitasRevistas()
        {
            return await Db.RECEITAS
                .AsNoTracking()
                .Include(r => r.Revista)
                .ToListAsync();
        }


    }
}
