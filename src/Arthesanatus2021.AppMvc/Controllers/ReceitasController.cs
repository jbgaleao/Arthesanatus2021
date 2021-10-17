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

        private readonly IInformacoesReceitaRepository _informacoesReceitaRepository;

        private readonly IMapper _mapper;

        public ReceitasController(IReceitaRepository receitaRepository, 
                                    IRevistaRepository revistaRepository,
                                    IReceitaService receitaService,
                                    IInformacoesReceitaRepository informacoesReceitaRepository,
                                    IMapper mapper)
        {
            _receitaRepository = receitaRepository;
            _revistaRepository = revistaRepository;
            _receitaService = receitaService;
            _informacoesReceitaRepository = informacoesReceitaRepository;
            _mapper = mapper;
        }


        [Route("lista-de-receitas")]
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<ReceitaViewModel>>(await _receitaRepository.ObterTodos()));

        }

        [Route("dados-da-receita/{id:guid}")]
        [HttpGet]
        public async Task<ActionResult> Details(Guid id)
        {
            var receitaViewModel = await ObterReceita(id);

            if (receitaViewModel == null)
            {
                return HttpNotFound();
            }

            return View(receitaViewModel);
        }



        [Route("nova-receita")]
        [HttpGet]
        public async Task<ActionResult> Create()
        {
            var receitaViewModel = await PopularRevista(new ReceitaViewModel());
            return View(receitaViewModel);
        }

        [Route("nova-receita")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ReceitaViewModel receitaViewModel)
        {
            receitaViewModel = await PopularRevista(receitaViewModel);

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
            ReceitaViewModel receitaViewModel = await ObterReceitaInformacoesReceita(id);
            
            if (receitaViewModel == null)
                return HttpNotFound();

            return View(receitaViewModel);
        }

        private async Task<ReceitaViewModel> ObterReceitaInformacoesReceita(Guid Id)
        {
            ReceitaViewModel receita = _mapper.Map<ReceitaViewModel>(await _receitaRepository.ObetrReceitaInformacoesReceitaPorId(Id));
            return receita;
        }









        [Route("editar-receita/{id:guid}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Guid id, ReceitaViewModel receitaViewModel)
        {
            if (id != receitaViewModel.Id) return HttpNotFound();
            
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

            ReceitaViewModel receitaViewModel = await ObterReceitaInformacoesReceita(id);
            if (receitaViewModel == null)
            {
                return HttpNotFound();
            }
            return View(receitaViewModel);
        }

        [Route("excluir-receita/{id:guid}")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            ReceitaViewModel receitaViewModel = await ObterReceitaInformacoesReceita(id);

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
            RevistaViewModel revistaViewModel = await ObterRevista(id);

            if (revistaViewModel == null)
            {
                return HttpNotFound();
            }
            return RedirectToAction("Details", "Revistas",revistaViewModel);
        }

        private async Task<ReceitaViewModel> ObterReceita(Guid Id)
        {
            ReceitaViewModel receita = _mapper.Map<ReceitaViewModel>(await _receitaRepository.ObterReceitaInformacoes(Id));
            receita.Revistas = _mapper.Map<IEnumerable<RevistaViewModel>>(await _revistaRepository.ObterTodos());
            return receita;
        }



        private async Task<ReceitaViewModel> PopularRevista(ReceitaViewModel receita)
        {
            receita.Revista = (RevistaViewModel)_mapper.Map<IEnumerable<RevistaViewModel>>(await _revistaRepository.ObterTodos());
            return receita;
        }








        private async Task<RevistaViewModel> ObterRevista(Guid Id)
        {
            RevistaViewModel receita = _mapper.Map<RevistaViewModel>(await _revistaRepository.ObterRevistaPorId(Id));
            return receita;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _receitaRepository.Dispose();
                _receitaService.Dispose();
                _revistaRepository.Dispose();
                _informacoesReceitaRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}