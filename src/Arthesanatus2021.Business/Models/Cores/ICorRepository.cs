using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Arthesanatus2021.Business.Core.Data;

namespace Arthesanatus2021.Business.Models.Cores
{
    public interface ICorRepository : IRepository<Cor>
    {
        Task<IEnumerable<Cor>> ObterCoresPorLinha(Guid linhaId);
       
    }
}
