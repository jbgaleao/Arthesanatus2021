using System.Collections.Generic;

using Arthesanatus2021.Business.Core.Models;
using Arthesanatus2021.Business.Models.Cores;
using Arthesanatus2021.Business.Models.Estoques;
using Arthesanatus2021.Business.Models.Receitas;

namespace Arthesanatus2021.Business.Models.Linhas
{
    public class Linha : Entity
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string DadosTecnicos { get; set; }


        /* EF Relations */
        public ICollection<Receita> ListaReceitas { get; set; }
        public ICollection<Cor> ListaCores { get; set; }
        public ICollection<Estoque> ListaEstoques { get; set; }

    }
}
'ujy1'