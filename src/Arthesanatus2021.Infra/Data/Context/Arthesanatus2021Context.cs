using Arthesanatus2021.Business.Models.Receitas;
using Arthesanatus2021.Business.Models.Revistas;
using Arthesanatus2021.Infra.Data.Mappings;

using System.Data.Entity;

namespace Arthesanatus2021.Infra.Data.Context
{
    public class Arthesanatus2021Context : DbContext
    {
        public Arthesanatus2021Context() : base("ArthesConnection")
        { }

        public DbSet<Revista> REVISTAS { get; set; }
        public DbSet<Receita> RECEITAS { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.Add(new RevistaMap());
            modelBuilder.Configurations.Add(new ReceitaMap());
        }
    }
}
