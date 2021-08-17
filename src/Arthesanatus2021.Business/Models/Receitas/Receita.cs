using Arthesanatus2021.Business.Core.Models;
using Arthesanatus2021.Business.Models.Revistas;
using System;

namespace Arthesanatus2021.Business.Models.Receitas
{
    public class Receita : Entity
    {        
        public Guid RevistaId { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }


        /* EF Relations */
        public Revista Revista { get; set; }
    }
}
