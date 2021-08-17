using Arthesanatus2021.Business.Models.Receitas;
using Arthesanatus2021.Business.Models.Revistas;

using System.Data.Entity;

namespace Arthesanatus2021.Infra.Data.Context
{
    public class Arthesanatus2021Context : DbContext
    {
        public Arthesanatus2021Context() : base("ArthesConnection")
        {

        }

        public DbSet<Revista> REVISTAS { get; set; }
        public DbSet<Receita> RECEITAS { get; set; }
    }
}
