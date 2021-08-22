using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace Arthesanatus2021.AppMvc.ViewModels
{
    public class ReceitaViewModel
    {
        public ReceitaViewModel()
        {
            Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        [DisplayName("Revista")]
        public Guid RevistaId { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        [DisplayName("Nome")]
        [StringLength(150, ErrorMessage = "O campo {0} deve ter até {1} caracteres!")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        [DisplayName("Descrição")]
        [StringLength(500, ErrorMessage = "O campo {0} deve ter até {1} caracteres!")]
        public string Descricao { get; set; }



        //[DisplayName("Imagem da Capa da revista")]
        //public HttpPostedFileBase ImagemUpload { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        [DisplayName("Foto")]
        public string Foto { get; set; }



        //public RevistaViewModel Revista { get; set; }
        //public IEnumerable<RevistaViewModel> Revistas { get; set; }
    }
}