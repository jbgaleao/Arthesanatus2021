using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using Arthesanatus2021.Business.Models.Estoques;

namespace Arthesanatus2021.Infra.Data.Mappings
{
    public class EstoqueMap : EntityTypeConfiguration<Estoque>
    {
        public EstoqueMap()
        {
            HasKey(est => est.Id);

            Property(est => est.QtdAberta)
                .IsRequired()
                .HasColumnName("QdtAberta")
                .HasColumnOrder(1)
                .HasColumnType("int");

            Property(est => est.QtdFechada)
                .IsRequired()
                .HasColumnName("QtdFechada")
                .HasColumnOrder(2)
                .HasColumnType("int");

            HasRequired(est => est.Linha)
                .WithMany(lin => lin.ListaEstoques)
                .HasForeignKey(est => est.LinhaId);

            HasRequired(est => est.Cor)
                .WithMany(cor => cor.ListaEstoques)
                .HasForeignKey(est => est.CorId);

            ToTable("ESTOQUES");
        }
    }
}
