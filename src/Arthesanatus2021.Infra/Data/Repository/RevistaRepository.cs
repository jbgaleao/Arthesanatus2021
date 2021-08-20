﻿using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

using Arthesanatus2021.Business.Models.Revistas;

namespace Arthesanatus2021.Infra.Data.Repository
{
    public class RevistaRepository : Repository<Revista>, IRevistaRepository
    {
        public async Task<Revista> ObterRevistaPorNumEdicao(int numEdicao)
        {
            return await Db.REVISTAS
                .AsNoTracking()
                .FirstOrDefaultAsync(r => r.NumeroEdicao == numEdicao);
        }

        public async Task<List<Revista>> ObterRevistasPorAno(int ano)
        {
            return await Db.REVISTAS
                .AsNoTracking()
                .Include(r => r.ListaReceitas)
                .Where(r => r.AnoEdicao == ano)
                .ToListAsync();
        }

        public IEnumerable<Revista> ObterRevistaPorMesEPorAno(Mes mes, int ano)
        {
            return Buscar(r => r.MesEdicao == mes && r.AnoEdicao == ano)
                .Result
                .ToList();
        }

    }
}
