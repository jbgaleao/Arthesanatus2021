using Arthesanatus2021.Business.Models.Receitas;

using System.Data.Entity.ModelConfiguration;

namespace Arthesanatus2021.Infra.Data.Mappings
{
    public class ReceitaMap : EntityTypeConfiguration<Receita>
    {
        public ReceitaMap()
        {
            HasKey(rec => rec.Id);

            Property(rec => rec.Nome)
                .IsRequired()
                .HasColumnName("Nome")
                .HasColumnOrder(2)
                .HasColumnType("varchar")
                .HasMaxLength(150);

            Property(rec => rec.Descricao)
                .IsRequired()
                .HasColumnName("Descricao")
                .HasColumnOrder(3)
                .HasColumnType("varchar")
                .HasMaxLength(2000);

            Property(rec => rec.Foto)
                .IsRequired()
                .HasColumnName("Foto")
                .HasColumnOrder(4)
                .HasColumnType("varchar")
                .HasMaxLength(2000);

            HasRequired(rec => rec.Revista)
                .WithMany(rev => rev.ListaReceitas)
                .HasForeignKey(rec => rec.RevistaId);

            
            HasMany(rec => rec.ListaLinhas)     // Receita tem uma lista de Linhas
                .WithMany(lin => lin.ListaReceitas)   // Linhas tem uma lista de Receitas
                .Map(m =>  // esse relacionamento será mapeado em uma terceira tabela
                {
                    m.MapLeftKey("ReceitaId");  // chave da esquerda será de ReceitaId
                    m.MapRightKey("LinhaId");   // chave da direita será LinhaId
                    m.ToTable("ReceitaLinha");  // nome da tabela será ReceitaLinha
                });



c
        }
    }
}
