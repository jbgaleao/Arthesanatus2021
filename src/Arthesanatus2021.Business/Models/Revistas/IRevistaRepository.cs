using Arthesanatus2021.Business.Core.Data;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Arthesanatus2021.Business.Models.Revistas
{
    public interface IRevistaRepository : IRepository<Revista>
    {
        Task<Revista> ObterRevistaPorNumEdicao(int numEdicao);

        Task<List<Revista>> ObterRevistasPorAno(int ano);

        Task<List<Revista>> ObterRevistaReceitas(Guid id);
    }
}
