using Arthesanatus2021.Business.Core.Data;
using Arthesanatus2021.Business.Models.Revistas;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Arthesanatus2021.Business.Models.Receitas
{
    public interface IReceitaRepository : IRepository<Receita>
    {
        Task<Receita> ObterReceitaInformacoes(Guid id);

        Task<Receita> ObterRevistaReceitaInformacoes(Guid id);
    }
}
