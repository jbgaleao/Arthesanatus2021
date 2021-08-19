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
                .HasColumnOrder(1)
                .HasColumnType("int");

            Property(cor => cor.Nome)
                .IsRequired()
                .HasColumnName("Nome")
                .HasColumnOrder(2)
                .HasColumnType("varchar")
                .HasMaxLength(150);

            HasRequired(cor => cor.Linha)
                .WithMany(lin => lin.ListaCores)
                .HasForeignKey(cor => cor.LinhaId);

            ToTable("CORES");

        }
    }
}
