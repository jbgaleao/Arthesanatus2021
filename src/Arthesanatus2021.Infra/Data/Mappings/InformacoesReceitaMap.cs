using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Arthesanatus2021.Business.Models.Cores;
using Arthesanatus2021.Business.Models.Receitas;

namespace Arthesanatus2021.Infra.Data.Mappings
{
    public class InformacoesReceitaMap : EntityTypeConfiguration<InformacoesReceita>
    {
        public InformacoesReceitaMap()
        {
            HasKey(inforec => inforec.Id);

            Property(inforec => inforec.NivelDificuldade)
                .IsRequired()
                .HasColumnName("NivelDificuldade")
                .HasColumnOrder(1)
                .HasColumnType("int");

            Property(inforec => inforec.Tamanho)
                .IsRequired()
                .HasColumnName("Nome")
                .HasColumnOrder(2)
                .HasColumnType("int");

            Property(inforec => inforec.OutrosMateriais)
                .IsRequired()
                .HasColumnName("OutrosMateriais")
                .HasColumnOrder(3)
                 .HasColumnType("varchar")
                 .HasMaxLength(1024);

            ToTable("INFORMACOESRECEITA");

        }
    }
}
