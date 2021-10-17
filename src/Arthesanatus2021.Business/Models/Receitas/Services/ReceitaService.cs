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
            receita.InformacoesReceita.Id = receita.Id;
            receita.InformacoesReceita.Receita = receita;

            if (!ExecutarValidacao(new ReceitaValidation(), receita) ||
                !ExecutarValidacao(new InformacoesReceitaValidation(), receita.InformacoesReceita))
                return;

            if (await ReceitaExistente(receita)) return;

            await _receitaRepository.Adicionar(receita);
            //await _informacoesreceitaRepository.Adicionar(receita.InformacoesReceita);
        }

        public async Task Atualizar(Receita receita)
        {
            if (!ExecutarValidacao(new ReceitaValidation(), receita) ||
                !ExecutarValidacao(new InformacoesReceitaValidation(), receita.InformacoesReceita))
                return;

            if (await (ReceitaExistente(receita))) return;

            await _receitaRepository.Atualizar(receita);            
            await _informacoesreceitaRepository.Atualizar(receita.InformacoesReceita);
        }

        public async Task Remover(Guid id)
        {
            var receita = await _receitaRepository.ObetrReceitaInformacoesReceitaPorId(id);
            if (receita.InformacoesReceita != null)
            {
                await _informacoesreceitaRepository.Remover(receita.InformacoesReceita.Id);
            }
            await _receitaRepository.Remover(id);
        }

        public async Task AtualizarInformacoesReceita(InformacoesReceita informacoesReceita)
        {
            if (!ExecutarValidacao(new InformacoesReceitaValidation(), informacoesReceita)) return;

            await _informacoesreceitaRepository.Atualizar(informacoesReceita);
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
            _informacoesreceitaRepository?.Dispose();
        }


    }
}
