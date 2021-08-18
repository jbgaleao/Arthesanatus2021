using Arthesanatus2021.Business.Core.Data;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Arthesanatus2021.Business.Models.Receitas
{
    public interface IReceitaRepository : IRepository<Receita>
    {
        Task<IEnumerable<Receita>> ObterReceitasPorRevista(Guid revistaId);
        Task<IEnumerable<Receita>> ObterRevistasReceitas();
        Task<Receita> ObterReceitaRevista(Guid receitaId);
    }
}
