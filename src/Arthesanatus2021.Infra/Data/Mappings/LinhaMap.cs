using System.Data.Entity.ModelConfiguration;

using Arthesanatus2021.Business.Models.Linhas;

namespace Arthesanatus2021.Infra.Data.Mappings
{
    public class LinhaMap : EntityTypeConfiguration<Linha>
    {
        public LinhaMap()
        {
            HasKey(lin => lin.Id);

            Property(lin => lin.Nome)
                .IsRequired()
                .HasColumnName("Nome")
                .HasColumnOrder(2)
                .HasColumnType("varchar")
                .HasMaxLength(150);

            Property(lin => lin.Descricao)
                .IsRequired()
                .HasColumnName("Descricao")
                .HasColumnOrder(3)
                .HasColumnType("varchar")
                .HasMaxLength(2000);

            Property(lin => lin.DadosTecnicos)
                .IsRequired()
                .HasColumnName("DadosTecnicos")
                .HasColumnOrder(4)
                .HasColumnType("varchar")
                .HasMaxLength(4000);




            ToTable("LINHAS");
        }
    }
}
