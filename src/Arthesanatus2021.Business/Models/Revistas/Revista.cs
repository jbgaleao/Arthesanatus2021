using Arthesanatus2021.Business.Core.Models;
using Arthesanatus2021.Business.Models.Receitas;

using System.Collections.Generic;

namespace Arthesanatus2021.Business.Models.Revistas
{
    public class Revista : Entity
    {
        public int NumeroEdicao { get; set; }
        public int AnoEdicao { get; set; }
        public Mes MesEdicao { get; set; }
        public string Tema { get; set; }
        public string Foto { get; set; }

        /* EF Relations */
        public ICollection<Receita> ListaReceitas { get; set; }

    }
}
