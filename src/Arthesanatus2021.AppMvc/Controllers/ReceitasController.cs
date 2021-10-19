using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;

using Arthesanatus2021.AppMvc.ViewModels;
using Arthesanatus2021.Business.Models.Receitas;
using Arthesanatus2021.Business.Models.Receitas.Services;
using Arthesanatus2021.Business.Models.Revistas;

using AutoMapper;

namespace Arthesanatus2021.AppMvc.Controllers
{
    public class ReceitasController : BaseController
    {
        private readonly IReceitaRepository _receitaRepository;
        private readonly IRevistaRepository _revistaRepository;
        private readonly IReceitaService _receitaService;
        private readonly IMapper _mapper;

        public ReceitasController(IReceitaRepository receitaRepository,
                                    IRevistaRepository revistaRepository,
                                    IReceitaService receitaService,
                                    IMapper mapper)
        {
            _receitaRepository = receitaRepository;
            _revistaRepository = revistaRepository;
            _receitaService = receitaService;
            _mapper = mapper;
        }


        [Route("lista-de-receitas")]
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<ReceitaViewModel>>(await _receitaRepository.ObterReceitasRevistas()));

        }

        [Route("dados-da-receita/{id:guid}")]
        [HttpGet]
        public async Task<ActionResult> Details(Guid id)
        {
            var receitaViewModel = await ObterReceita(id);

            return receitaViewModel == null ? HttpNotFound() : View(receitaViewModel);
        }



        [Route("nova-receita")]
        [HttpGet]
        public async Task<ActionResult> Create()
        {
            ReceitaViewModel receitaViewModel = await PopularRevistas(new ReceitaViewModel());
            return View(receitaViewModel);
        }

        [Route("nova-receita")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ReceitaViewModel receitaViewModel)
        {
            receitaViewModel = await PopularRevistas(receitaViewModel);

            if (ModelState.IsValid)
            {
                await _receitaService.Adicionar(_mapper.Map<Receita>(receitaViewModel));
                return RedirectToAction("Index");
            }

            return View(receitaViewModel);
        }



        [Route("editar-receita/{id:guid}")]
        [HttpGet]
        public async Task<ActionResult> Edit(Guid id)
        {
            ReceitaViewModel receitaViewModel = await ObterReceita(id);
            return receitaViewModel == null ? HttpNotFound() : View(receitaViewModel);
        }

        [Route("editar-receita/{id:guid}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(ReceitaViewModel receitaViewModel)
        {
            if (ModelState.IsValid)
            {

                await _receitaService.Atualizar(_mapper.Map<Receita>(receitaViewModel));
                return RedirectToAction("Index");
            }
            return View(receitaViewModel);
        }



        [Route("excluir-receita/{id:guid}")]
        [HttpGet]
        public async Task<ActionResult> Delete(Guid id)
        {

            var receitaViewModel = await ObterReceita(id);
            return receitaViewModel == null ? HttpNotFound() : View(receitaViewModel);
        }

        [Route("excluir-receita/{id:guid}")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            var receitaViewModel = await ObterReceita(id);
            if (receitaViewModel == null)
            {
                return HttpNotFound();
            }

            await _receitaService.Remover(id);

            return RedirectToAction("Index");
        }

        //---------------------------------------------------------------------------------

        [Route("revista-relacionada/{id:guid}")]
        [HttpGet]
        public async Task<ActionResult> RevistaRelacionada(Guid id)
        {
            var revistaViewModel = await ObterRevista(id);

            return revistaViewModel == null ? HttpNotFound() : RedirectToAction("Details", "Revistas", revistaViewModel);
        }

        private async Task<ReceitaViewModel> ObterReceita(Guid Id)
        {
            var receita = _mapper.Map<ReceitaViewModel>(await _receitaRepository.ObterReceitaRevista(Id));
            receita.Revistas = _mapper.Map<IEnumerable<RevistaViewModel>>(await _revistaRepository.ObterTodos());
            return receita;
        }

        private async Task<RevistaViewModel> ObterRevista(Guid Id)
        {
            var receita = _mapper.Map<RevistaViewModel>(await _revistaRepository.ObterRevistaPorId(Id));
            return receita;
        }

        private async Task<ReceitaViewModel> PopularRevistas(ReceitaViewModel receita)
        {
            receita.Revistas = _mapper.Map<IEnumerable<RevistaViewModel>>(await _revistaRepository.ObterTodos());
            return receita;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _receitaRepository.Dispose();
                _receitaService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}