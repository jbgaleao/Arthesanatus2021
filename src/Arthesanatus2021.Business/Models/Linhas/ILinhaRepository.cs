using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Arthesanatus2021.Business.Core.Data;
using Arthesanatus2021.Business.Models.Linhas;

namespace Arthesanatus2021.Business.Models.Linhas
{
    public interface ILinhaRepository : IRepository<Linha>
    {
        Task<IEnumerable<Linha>> ObterLinhasCorEstoque(Guid linhaId);
    }
}
