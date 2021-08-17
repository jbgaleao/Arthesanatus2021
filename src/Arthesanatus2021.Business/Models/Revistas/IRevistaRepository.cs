using Arthesanatus2021.Business.Core.Data;

using System;
using System.Threading.Tasks;

namespace Arthesanatus2021.Business.Models.Revistas
{
    public interface IRevistaRepository : IRepository<Revista>
    {
        Task<Revista> ObterRevistaReceita(Guid id);
    }
}
