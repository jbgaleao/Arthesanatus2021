using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Arthesanatus2021.Business.Core.Data;

namespace Arthesanatus2021.Business.Models.Receitas
{
    public interface IInformacoesReceita:IRepository<InformacoesReceita>
    {
        Task<InformacoesReceita> ObterInformacoesReceitaPorReceita(Guid receitaId);
    }
}
