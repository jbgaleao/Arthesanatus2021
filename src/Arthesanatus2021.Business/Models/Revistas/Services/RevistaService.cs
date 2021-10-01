using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Arthesanatus2021.Business.Core.Notificacoes;
using Arthesanatus2021.Business.Core.Services;
using Arthesanatus2021.Business.Models.Revistas.Validations;

namespace Arthesanatus2021.Business.Models.Revistas.Services
{
    public class RevistaService : BaseService, IRevistaService
    {

        protected readonly IRevistaRepository _revistaRepository;

        public RevistaService(IRevistaRepository revistaRepository, INotificador notificador) : base(notificador)
        {
            _revistaRepository = revistaRepository;
        }



        public async Task Adicionar(Revista revista)
        {
            if (!ExecutarValidacao(new RevistaValidation(), revista)) 
                return;

            if (await RevistaExistente(revista)) 
                return;

            await _revistaRepository.Adicionar(revista);
  
        }

        public async Task Atualizar(Revista revista)
        {
            if (!ExecutarValidacao(new RevistaValidation(), revista)) 
                return;

            if (await RevistaExistente(revista)) 
                return;

            await _revistaRepository.Atualizar(revista);            
        }

        public async Task Remover(Guid id)
        {
            var revista = await _revistaRepository.ObterRevistaPorId(id);

            if (revista.ListaReceitas != null)
            {
                Notificar("A Revista possui Receitas cadastradas!");
                return;
            }

            await _revistaRepository.Remover(id);

        }        
        
        



        private async Task<bool> RevistaExistente (Revista revista)
        {
            var revistaAtual = await _revistaRepository.Buscar(r => r.Id != revista.Id 
                    && r.NumeroEdicao == revista.NumeroEdicao 
                    && r.AnoEdicao == r.AnoEdicao
                    && r.MesEdicao == revista.MesEdicao);

            if (!revistaAtual.Any())
            {
                return false;
            }

            Notificar("Já existe uma Revista cadastrada com esses dados!");

            return true;
        }

        public void Dispose()
        {
            _revistaRepository?.Dispose();
        }
    }
}
