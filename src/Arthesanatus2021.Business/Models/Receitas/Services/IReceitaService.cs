using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arthesanatus2021.Business.Models.Receitas.Services
{
    public interface IReceitaService :IDisposable
    {
        Task Adicionar(Receita receita);
        Task Atualizar(Receita receita);
        Task Remover(Guid id);

        Task AtualizarInformacoesReceita(InformacoesReceita informacoesReceita);
    }
}
