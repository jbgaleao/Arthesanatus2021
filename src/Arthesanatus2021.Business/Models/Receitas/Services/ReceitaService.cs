using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Arthesanatus2021.Business.Core.Notificacoes;
using Arthesanatus2021.Business.Core.Services;
using Arthesanatus2021.Business.Models.Receitas.Validations;

namespace Arthesanatus2021.Business.Models.Receitas.Services
{
    public class ReceitaService : BaseService, IReceitaService
    {
        private readonly IReceitaRepository _receitaRepository;
        private readonly IInformacoesReceitaRepository _informacoesreceitaRepository;

        public ReceitaService(IReceitaRepository receitaRepository, 
                              IInformacoesReceitaRepository informacoesreceitaRepository, 
                              INotificador notificador) : base(notificador)
        {
            _receitaRepository = receitaRepository;
            _informacoesreceitaRepository = informacoesreceitaRepository;
        }




        public async Task Adicionar(Receita receita)
        {
            if (!ExecutarValidacao(new ReceitaValidation(), receita) ||
                !ExecutarValidacao(new InformacoesReceitaValidation(), receita.InformacoesReceita))
                return;
            
            if (await (ReceitaExistente(receita))) return;
          
            await _receitaRepository.Adicionar(receita);
        }

        public async Task Atualizar(Receita receita)
        {
            if (!ExecutarValidacao(new ReceitaValidation(), receita) ||
                !ExecutarValidacao(new InformacoesReceitaValidation(), receita.InformacoesReceita))
                return;

            if (await (ReceitaExistente(receita))) return;

            await _receitaRepository.Atualizar(receita);
        }

        public async Task Remover(Guid id)
        {
            var receita = await _receitaRepository.ObetrReceitaInformacoesReceitaPorId(id);
            if (receita.InformacoesReceita.)
            {

            }
            await _receitaRepository.Remover(id);
        }

        public Task AtualizarInformacoesReceita(InformacoesReceita informacoesReceita)
        {
            throw new NotImplementedException();
        }        
        
        
        private async Task<bool> ReceitaExistente(Receita receita)
        {
            var receitaAtual = await _receitaRepository
                                        .Buscar(r => r.Id == receita.Id);
            return receitaAtual.Any();

        }

        public void Dispose()
        {
            _receitaRepository?.Dispose();
        }


    }
}
