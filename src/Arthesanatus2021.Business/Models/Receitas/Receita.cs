using Arthesanatus2021.Business.Core.Models;
using Arthesanatus2021.Business.Models.Linhas;
using Arthesanatus2021.Business.Models.Revistas;

using System;
using System.Collections.Generic;

namespace Arthesanatus2021.Business.Models.Receitas
{
    public class Receita : Entity
    {
        public Guid RevistaId { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Foto { get; set; }


        /* EF Relations */
        public Revista Revista { get; set; }

        public ICollection<Linha> ListaLinhas { get; set; }
    }
}
