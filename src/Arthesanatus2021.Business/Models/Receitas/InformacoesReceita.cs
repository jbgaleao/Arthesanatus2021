using Arthesanatus2021.Business.Core.Models;

namespace Arthesanatus2021.Business.Models.Receitas
{
    public class InformacoesReceita : Entity
    {
        public NivelDificuldade NivelDificuldade { get; set; }
        public int Tamanho { get; set; }
        public string OutrosMateriais { get; set; }

        public Receita Receita { get; set; }
    }
}
