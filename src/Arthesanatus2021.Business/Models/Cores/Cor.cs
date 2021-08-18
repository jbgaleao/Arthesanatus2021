﻿
using System;

using Arthesanatus2021.Business.Core.Models;
using Arthesanatus2021.Business.Models.Linhas;

namespace Arthesanatus2021.Business.Models.Cores
{
    public class Cor : Entity
    {        
        public Guid LinhaId { get; set; }
        public int CorCodigo { get; set; }
        public string Nome { get; set; }
        public int QtdAberta { get; set; }
        public int QtdFechada { get; set; }


        /* EF Relations */
        public Linha Linha { get; set; }
    }
}