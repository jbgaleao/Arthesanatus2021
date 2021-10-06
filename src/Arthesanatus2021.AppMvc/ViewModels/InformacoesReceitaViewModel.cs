using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

using Arthesanatus2021.Business.Models.Receitas;

namespace Arthesanatus2021.AppMvc.ViewModels
{
    public class InformacoesReceitaViewModel
    {
        public InformacoesReceitaViewModel()
        {
            Id = Guid.NewGuid();
        }


        [Key]
        public Guid Id { get; set; }


        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [Display(Name = "Nível de Dificuldade")]
        public NivelDificuldade NivelDificuldade { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [Display(Name = "Tamanho")]
        [Range(1, 80, ErrorMessage = "O Campo {0} deve estar entre {1} e {2}")]
        public int Tamanho { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [Display(Name = "Outros Materiais")]
        [StringLength(1024, ErrorMessage = "O campo {0} é obrigatório")]
        public string OutrosMateriais { get; set; }

        [HiddenInput]
        public Guid RevistaId { get; set; }
    }
}