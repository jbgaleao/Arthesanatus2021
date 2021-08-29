using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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
        private readonly IRevistaService _revistaService;
        private readonly IMapper _mapper;

        public RevistasController(IRevistaRepository revistaRepository, IRevistaService revistaService, IMapper mapper)
        {
            _revistaRepository = revistaRepository;
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
                return HttpNotFound();

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
        public async Task<ActionResult> Create(RevistaViewModel revistaViewModel)
        {
            if (!ModelState.IsValid)
                return View(revistaViewModel);

            var revista = _mapper.Map<Revista>(revistaViewModel);
            await _revistaService.Adicionar(revista);

            return RedirectToAction("Index");
        }




        [Route("editar-revista/{id:guid}")]
        [HttpGet]
        public async Task<ActionResult> Edit(Guid id)
        {
            var revistaViewModel = await ObterRevista(id);
            if (revistaViewModel == null)
                return HttpNotFound();

            return View(revistaViewModel);
        }

        [Route("editar-revista/{id:guid}")]
        [HttpPost]
        public async Task<ActionResult> Edit(Guid id, RevistaViewModel revistaViewModel)
        {
            if (id != revistaViewModel.Id)
                return HttpNotFound();

            if (!ModelState.IsValid)
                return View(revistaViewModel);

            var revista = _mapper.Map<Revista>(revistaViewModel);
            await _revistaService.Atualizar(revista);

            // TODO:
            // em caso de erro

            return RedirectToAction("Index");
        }



        [Route("excluir-revista/{id:guid}")]
        [HttpGet]
        public async Task<ActionResult> Delete(Guid id)
        {
            var revistaViewModel = await ObterRevista(id);
            if (revistaViewModel == null)
                return HttpNotFound();

            return View(revistaViewModel);
        }

        [Route("excluir-revista/{id:guid}")]
        [HttpPost, ActionName("Delete")]
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




        private async Task<RevistaViewModel> ObterRevista(Guid id)
        {
            var revista = _mapper.Map<RevistaViewModel>(await _revistaRepository.ObterPorId(id));
            return revista;
        }

        private async Task<RevistaViewModel> ObterRevistaReceitas(Guid id)
        {
            return _mapper.Map<RevistaViewModel>(await _revistaRepository.ObterRevistaReceitas(id));
        }
    }
}