using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

using Arthesanatus2021.AppMvc.ViewModels;
using Arthesanatus2021.Business.Models.Receitas;
using Arthesanatus2021.Business.Models.Receitas.Services;
using Arthesanatus2021.Business.Models.Revistas;
using Arthesanatus2021.Business.Models.Revistas.Services;

using AutoMapper;

namespace Arthesanatus2021.AppMvc.Controllers
{
    public class RevistasController : BaseController
    {
        private readonly IRevistaRepository _revistaRepository;
        private readonly IReceitaRepository _receitaRepository;
        private readonly IRevistaService _revistaService;
        private readonly IMapper _mapper;

        public RevistasController(IRevistaRepository revistaRepository, IRevistaService revistaService,
            IReceitaRepository receitaRepository, IMapper mapper)
        {
            _revistaRepository = revistaRepository;
            _receitaRepository = receitaRepository;
            _revistaService = revistaService;
            _mapper = mapper;
        }


        [Route("lista-de-revistas")]
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<RevistaViewModel>>(await _revistaRepository.ObterTodos()));

        }




        [Route("dados-da-revista")]
        [HttpGet]
        public async Task<ActionResult> Details(Guid id)
        {
            var revistaViewModel = await ObterRevista(id);
            if (revistaViewModel == null)
            {
                return HttpNotFound();
            }
            return View(revistaViewModel);
        }


        [Route("nova-revista")]
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }


        [Route("nova-revista")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(RevistaViewModel revistaViewModel)
        {
            if (!ModelState.IsValid) { return View(revistaViewModel); }

            string prefixo = Guid.NewGuid() + "_";
            if (!UploadImagem(revistaViewModel.ImagemUpload, prefixo))
            {
                return View(revistaViewModel);
            }
            revistaViewModel.Foto = prefixo + revistaViewModel.ImagemUpload.FileName;
            await _revistaService.Adicionar(_mapper.Map<Revista>(revistaViewModel));
            return RedirectToAction("Index");
        }


        private bool UploadImagem(HttpPostedFileBase img, string prefixo)
        {
            if (img == null || img.ContentLength <= 0)
            {
                ModelState.AddModelError(string.Empty, "Imagem em formato Inválido");
                return false;
            }

            string path = Path.Combine(HttpContext.Server.MapPath("~/imagens"), prefixo + img.FileName);

            if (System.IO.File.Exists(path))
            {
                ModelState.AddModelError(string.Empty, "Já existe um arquivo com esse Nome");
                return false;
            }

            img.SaveAs(path);
            return true;
        }

        private ActionResult NewMethod(RevistaViewModel revistaViewModel)
        {
            return View(revistaViewModel);
        }

        [Route("editar-revista/{id:guid}")]
        [HttpGet]
        public async Task<ActionResult> Edit(Guid id)
        {
            RevistaViewModel revistaViewModel = await ObterRevista(id);
            if (revistaViewModel == null)
            {
                return HttpNotFound();
            }
            return View(revistaViewModel);
        }

        [Route("editar-revista/{id:guid}")]
        [HttpPost]
        public async Task<ActionResult> Edit(Guid id, RevistaViewModel revistaViewModel)
        {
            if (id != revistaViewModel.Id) return HttpNotFound();

            if (!ModelState.IsValid) return View(revistaViewModel);
            RevistaViewModel revistaAtualizacao = await ObterRevista(revistaViewModel.Id);

            revistaViewModel.Foto = revistaAtualizacao.Foto;

            if (revistaViewModel.ImagemUpload != null)
            {
                string imgPrefixo = Guid.NewGuid() + "_";
                if (!UploadImagem(revistaViewModel.ImagemUpload, imgPrefixo))
                {
                    return View(revistaViewModel);
                }

                revistaAtualizacao.Foto = imgPrefixo + revistaViewModel.ImagemUpload.FileName;
            }

            revistaAtualizacao.NumeroEdicao = revistaViewModel.NumeroEdicao;
            revistaAtualizacao.MesEdicao = revistaViewModel.MesEdicao;
            revistaAtualizacao.AnoEdicao = revistaViewModel.AnoEdicao;
            revistaAtualizacao.Tema = revistaViewModel.Tema;


            await _revistaService.Atualizar(_mapper.Map<Revista>(revistaAtualizacao));

            return RedirectToAction("Index");
        }



        [Route("excluir-revista/{id:guid}")]
        [HttpGet]
        public async Task<ActionResult> Delete(Guid id)
        {
            var revistaViewModel = await ObterRevista(id);
            if (revistaViewModel == null)
            {
                return HttpNotFound();
            }
            return View(revistaViewModel);
        }

        [Route("excluir-revista/{id:guid}")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            var revistaViewModel = await ObterRevista(id);
            if (revistaViewModel == null)
                return HttpNotFound();

            await _revistaService.Remover(id);

            // TODO:
            // em caso de erro

            return RedirectToAction("Index");
        }




        [Route("lista-receitas-revista/{id:int}")]
        [HttpGet]
        public async Task<ActionResult> ListaReceitas(int id)
        {
            var revista = await _revistaRepository.ObterRevistaPorNumEdicao(id);
            if (revista.ListaReceitas == null)
            {
                return HttpNotFound();
            }
            var _receitaViewModel = _mapper.Map<IEnumerable<ReceitaViewModel>>(revista.ListaReceitas);

            return RedirectToAction("Index", "Receitas", _receitaViewModel);
        }






        private async Task<RevistaViewModel> ObterRevista(Guid id)
        {
            var revista = _mapper.Map<RevistaViewModel>(await _revistaRepository.ObterRevistaPorId(id));
            return revista;
        }

        private async Task<RevistaViewModel> ObterRevistaReceitas(Guid id)
        {
            return _mapper.Map<RevistaViewModel>(await _revistaRepository.ObterRevistaReceitas(id));
        }

    }
}