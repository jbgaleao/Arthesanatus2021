using System.ComponentModel;

namespace Arthesanatus2021.Business.Models.Receitas
{
    public enum NivelDificuldade
    {
        [Description("AVANÇADO")]
        Avancado = 1,
        [Description("INTERMEDIÁRIO")]
        Intermediario = 2,
        [Description("BÁSICO")]
        Basico = 3
    }
}