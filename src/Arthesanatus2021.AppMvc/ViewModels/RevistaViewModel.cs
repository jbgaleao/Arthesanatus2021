using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

using Arthesanatus2021.Business.Models.Revistas;

namespace Arthesanatus2021.AppMvc.ViewModels
{
    public class RevistaViewModel
    {
        public RevistaViewModel()
        {
            Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }

        [Display(Name = "Número Edição")]
        [Required(ErrorMessage = "O Campo {0} é obrigatório!")]
        [Range(1, 999, ErrorMessage = "O Campo {0} deve estar entre {1} e {2}")]
        public int NumeroEdicao { get; set; }

        [Display(Name = "Ano Edição")]
        [Required(ErrorMessage = "O Campo {0} é obrigatório!")]
        [Range(2017, 2030, ErrorMessage = "O Campo {0} deve estar entre {1} e {2}")]
        public int AnoEdicao { get; set; }

        [Display(Name = "Mês Edição")]
        [Required(ErrorMessage = "O Campo {0} é obrigatório!")]
        public Mes MesEdicao { get; set; }

        [Display(Name = "Tema da Revista")]
        [Required(ErrorMessage = "O Campo {0} é obrigatório!")]
        [MaxLength(150, ErrorMessage = "O Campo {0} deverá ter o máximo de {1} caracteres!")]
        public string Tema { get; set; }

        [Required(ErrorMessage = "O Campo {0} é obrigatório!")]
        [MaxLength(500, ErrorMessage = "O Campo {0} deverá ter o máximo de {1} caracteres!")]
        public string Foto { get; set; }

        public IEnumerable<ReceitaViewModel> Receitas { get; set; }
    }
}