using Arthesanatus2021.Business.Core.Models;
using FluentValidation;

namespace Arthesanatus2021.Business.Core.Services
{
    public abstract class BaseService
    {
        protected bool ExecutarValidacao<TV, TE>(TV validacao, TE entidade) where TV : AbstractValidator<TE> where TE : Entity
        {
            var validator = validacao.Validate(entidade);
            return validator.IsValid;
        }
    }
}
