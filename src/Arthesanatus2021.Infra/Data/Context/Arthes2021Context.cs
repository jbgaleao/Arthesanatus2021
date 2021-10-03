using Arthesanatus2021.Business.Models.Cores;
using Arthesanatus2021.Business.Models.Estoques;
using Arthesanatus2021.Business.Models.Linhas;
using Arthesanatus2021.Business.Models.Receitas;
using Arthesanatus2021.Business.Models.Revistas;
using Arthesanatus2021.Infra.Data.Mappings;

using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Arthesanatus2021.Infra.Data.Context
{
    public class Arthes2021Context : DbContext
    {
        public Arthes2021Context() : base("ArthesConn")
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<Revista> REVISTAS { get; set; }
        public DbSet<Receita> RECEITAS { get; set; }
        public DbSet<Linha> LINHAS { get; set; }
        public DbSet<Cor> CORES { get; set; }
        public DbSet<Estoque> ESTOQUES { get; set; }
        public DbSet<InformacoesReceita> INFORMACOESRECEITAS { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Configurations.Add(new RevistaMap());
            modelBuilder.Configurations.Add(new ReceitaMap());
            modelBuilder.Configurations.Add(new LinhaMap());
            modelBuilder.Configurations.Add(new CorMap());
            modelBuilder.Configurations.Add(new EstoqueMap());
            modelBuilder.Configurations.Add(new InformacoesReceitaMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
