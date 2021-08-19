using System;

using Arthesanatus2021.Business.Core.Models;
using Arthesanatus2021.Business.Models.Cores;
using Arthesanatus2021.Business.Models.Linhas;

namespace Arthesanatus2021.Business.Models.Estoques
{
    public class Estoque : Entity
    {
        public Guid LinhaId { get; set; }
        public Guid CorId { get; set; }
        public int QtdAberta { get; set; }
        public int QtdFechada { get; set; }



        /* EF Relations */
        public Linha Linha { get; set; }
        public Cor Cor { get; set; }
    }
}
