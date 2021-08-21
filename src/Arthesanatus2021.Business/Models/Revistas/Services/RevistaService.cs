using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Arthesanatus2021.Business.Core.Services;
using Arthesanatus2021.Business.Models.Revistas.Validations;

namespace Arthesanatus2021.Business.Models.Revistas.Services
{
    public class RevistaService : BaseService, IRevistaService
    {

        protected readonly IRevistaRepository _revistaRepository;

        public RevistaService(IRevistaRepository revistaRepository)
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
            var revista = await _revistaRepository.ObterPorId(id);
            
            if (revista.ListaReceitas.Any())
                return;

            await _revistaRepository.Remover(id);

        }        
        
        



        private async Task<bool> RevistaExistente (Revista revista)
        {
            var revistaAtual = await _revistaRepository.Buscar(r => r.Id != revista.Id 
                    && r.NumeroEdicao == revista.NumeroEdicao 
                    && r.AnoEdicao == r.AnoEdicao
                    && r.MesEdicao == revista.MesEdicao);

            return revistaAtual.Any();
        }

        public void Dispose()
        {
            _revistaRepository?.Dispose();
        }
    }
}
