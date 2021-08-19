
using System;
using System.Threading.Tasks;

using Arthesanatus2021.Business.Core.Data;

namespace Arthesanatus2021.Business.Models.Estoques
{
    public interface IEstoqueRepository : IRepository<Estoque>
    {
        Task<int> ObterQtdAbertasPorLinhaCor(Guid linhaId, Guid corId);
        Task<int> ObterQtdFechadasPorLinhaCor(Guid linhaId, Guid corId);
    }
}
