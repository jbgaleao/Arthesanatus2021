using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

using Arthesanatus2021.Business.Models.Revistas;
using Arthesanatus2021.Business.Models.Revistas.Services;
using Arthesanatus2021.Infra.Data.Repository;

namespace Arthesanatus2021.AppMvc.Controllers
{
    public class RevistasController : Controller
    {
        private readonly IRevistaService _revistaService;

        public RevistasController()
        {
            _revistaService = new RevistaService(new RevistaRepository());
        }

        public async Task<ActionResult> Index()
        {
            var revista = new Revista()
            {
                NumeroEdicao = 1,
                MesEdicao = Mes.JANEIRO,
                AnoEdicao = 2029,
                Tema = "Aniversário GUANABARA",
                Foto = "Caminho da Foto"
            };

            
            await _revistaService.Atualizar(revista);

            return new EmptyResult();
        }
    }
}