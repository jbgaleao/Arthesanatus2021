using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arthesanatus2021.Business.Models.Revistas.Services
{
    public interface IRevistaService : IDisposable
    {
        Task Adicionar(Revista revista);
        Task Atualizar(Revista revista);
        Task Remover(Guid id);
    }
}
