using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Arthesanatus2021.AppMvc.Models;
using Arthesanatus2021.AppMvc.ViewModels;
using Arthesanatus2021.Business.Models.Receitas;
using Arthesanatus2021.Business.Models.Receitas.Services;
using Arthesanatus2021.Infra.Data.Repository;
using Arthesanatus2021.Business.Core.Notificacoes;
using AutoMapper;

namespace Arthesanatus2021.AppMvc.Controllers
{
    public class ReceitasController : Controller
    {
        private readonly IReceitaRepository _receitaRepository;
        private readonly IReceitaService _receitaService;
        private readonly IMapper _mapper;

        public ReceitasController()
        {

        }

        public async Task<ActionResult> Index()
        {
            var receitasVM = _mapper.Map<IEnumerable<ReceitaViewModel>>(await _receitaRepository.ObterTodos());
            return View(receitasVM);
        }


        public async Task<ActionResult> Details(Guid id)
        {
            var receitaViewModel = await ObterReceita(id);

            if (receitaViewModel == null)
            {
                return HttpNotFound();
            }
            return View(receitaViewModel);
        }

        // GET: Receitas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Receitas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ReceitaViewModel receitaViewModel)
        {
            if (ModelState.IsValid)
            {
                await _receitaService.Adicionar(_mapper.Map<Receita>(receitaViewModel));
                return RedirectToAction("Index");
            }

            return View(receitaViewModel);
        }

        // GET: Receitas/Edit/5
        public async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReceitaViewModel receitaViewModel = await db.ReceitaViewModels.FindAsync(id);
            if (receitaViewModel == null)
            {
                return HttpNotFound();
            }
            return View(receitaViewModel);
        }

        // POST: Receitas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,RevistaId,Nome,Descricao,Foto")] ReceitaViewModel receitaViewModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(receitaViewModel).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(receitaViewModel);
        }

        // GET: Receitas/Delete/5
        public async Task<ActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReceitaViewModel receitaViewModel = await db.ReceitaViewModels.FindAsync(id);
            if (receitaViewModel == null)
            {
                return HttpNotFound();
            }
            return View(receitaViewModel);
        }

        // POST: Receitas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            ReceitaViewModel receitaViewModel = await db.ReceitaViewModels.FindAsync(id);
            db.ReceitaViewModels.Remove(receitaViewModel);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private async Task<ReceitaViewModel> ObterReceita(Guid Id)
        {
            var receita = _mapper.Map<ReceitaViewModel>(await _receitaRepository.ObterPorId(Id));
            return receita;
        }





        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
