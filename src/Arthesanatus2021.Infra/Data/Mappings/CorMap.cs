using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Arthesanatus2021.Business.Models.Cores;

namespace Arthesanatus2021.Infra.Data.Mappings
{
    public class CorMap : EntityTypeConfiguration<Cor>
    {
        public CorMap()
        {
            HasKey(cor => cor.Id);

            Property(cor => cor.CorCodigo)
                .IsRequired()
                .HasColumnName("CorCodigo")
                .HasColumnOrder(2)
                .HasColumnType("int");

            Property(cor => cor.Nome)
                .IsRequired()
                .HasColumnName("Nome")
                .HasColumnOrder(3)
                .HasColumnType("varchar")
                .HasMaxLength(150);

            Property(cor => cor.QtdAberta)
                .IsRequired()
                .HasColumnName("QdtAberta")
                .HasColumnOrder(4)
                .HasColumnType("int");

            Property(cor => cor.QtdFechada)
                .IsRequired()
                .HasColumnName("QtdFechada")
                .HasColumnOrder(5)
                .HasColumnType("int");


            HasRequired(cor => cor.Linha)
                .WithMany(lin => lin.ListaCores)
                .HasForeignKey(cor => cor.LinhaId);

            ToTable("CORES");

        }
    }
}
