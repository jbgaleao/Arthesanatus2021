using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Arthesanatus2021.Business.Core.Services;
using Arthesanatus2021.Business.Models.Receitas.Validations;

namespace Arthesanatus2021.Business.Models.Receitas.Services
{
    public class ReceitaService : BaseService, IReceitaService
    {
        private readonly IReceitaRepository _receitaRepository;

        public ReceitaService(IReceitaRepository receitaRepository)
        {
            _receitaRepository = receitaRepository;
        }

        public async Task Adicionar(Receita receita)
        {
            if (!ExecutarValidacao(new ReceitaValidation(), receita))
                return;

            await _receitaRepository.Adicionar(receita);
        }

        public async Task Atualizar(Receita receita)
        {
            if (!ExecutarValidacao(new ReceitaValidation(), receita))
                return;

            await _receitaRepository.Atualizar(receita);
        }

        public async Task Remover(Guid id)
        {
            await _receitaRepository.Remover(id);
        }
         
        public void Dispose()
        {
            _receitaRepository?.Dispose();
        }
    }
}
