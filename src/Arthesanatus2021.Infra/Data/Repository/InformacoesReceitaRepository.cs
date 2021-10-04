using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Arthesanatus2021.Business.Models.Receitas;
using Arthesanatus2021.Infra.Data.Context;

namespace Arthesanatus2021.Infra.Data.Repository
{
    public class InformacoesReceitaRepository: Repository<InformacoesReceita>, IInformacoesReceitaRepository
    {
        public InformacoesReceitaRepository(Arthes2021Context context) : base(context) { }

        public async Task<InformacoesReceita> ObterInformacoesReceitaDeReceita(Guid receitaId)
        {
            return await ObterPorId(receitaId);
        }
    }
}
