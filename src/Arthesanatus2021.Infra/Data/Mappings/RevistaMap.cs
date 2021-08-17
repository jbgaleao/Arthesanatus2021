using Arthesanatus2021.Business.Models.Revistas;

using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;

namespace Arthesanatus2021.Infra.Data.Mappings
{
    public class RevistaMap : EntityTypeConfiguration<Revista>
    {
        public RevistaMap()
        {
            HasKey(rev => rev.Id);

            Property(rev => rev.NumeroEdicao)
                .IsRequired()
                .HasColumnName("NumeroEdicao")
                .HasColumnOrder(2)
                .HasColumnType("int")
                .HasColumnAnnotation("IX_NumeroEdicao", new IndexAnnotation(new IndexAttribute { IsUnique = true }));

            Property(rev => rev.MesEdicao)
                .IsRequired()
                .HasColumnName("MesEdicao")
                .HasColumnOrder(3)
                .HasColumnType("int");

            Property(rev => rev.AnoEdicao)
                .IsRequired()
                .HasColumnName("AnoEdicao")
                .HasColumnOrder(4)
                .HasColumnType("int");

            Property(rev => rev.Tema)
                 .IsRequired()
                 .HasColumnName("Tema")
                 .HasColumnOrder(5)
                 .HasColumnType("varchar")
                 .HasMaxLength(150);

            Property(rev => rev.Foto)
                 .IsRequired()
                 .HasColumnName("Foto")
                 .HasColumnOrder(6)
                 .HasColumnType("varchar")
                 .HasMaxLength(500);

            ToTable("REVISTAS");

        }
    }
}
