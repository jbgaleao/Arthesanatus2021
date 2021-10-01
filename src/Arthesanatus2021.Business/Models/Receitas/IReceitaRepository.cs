using Arthesanatus2021.Business.Core.Data;
using Arthesanatus2021.Business.Models.Revistas;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Arthesanatus2021.Business.Models.Receitas
{
    public interface IReceitaRepository : IRepository<Receita>
    {        
        Task<Receita> ObterReceitaRevista(Guid receitaId);
        
        Task<IEnumerable<Receita>> ObterReceitasPorRevistaNumEdicao(int numEdicao);
        
        Task<IEnumerable<Receita>> ObterReceitasPorRevistaMesEdicao(Mes mes);
        
        Task<IEnumerable<Receita>> ObterReceitasPorRevistaAnoEdicao(int ano);
        
        Task<IEnumerable<Receita>> ObterReceitasPorRevistaMesEdicaoAnoEdicao(Mes mes, int ano);

        Task<IEnumerable<Receita>> ObterReceitasRevistas();
        
    }
}
