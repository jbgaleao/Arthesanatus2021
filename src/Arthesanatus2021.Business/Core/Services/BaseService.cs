using System;

using Arthesanatus2021.Business.Core.Models;
using Arthesanatus2021.Business.Core.Notificacoes;

using FluentValidation;
using FluentValidation.Results;

namespace Arthesanatus2021.Business.Core.Services
{
    public abstract class BaseService
    {
        private readonly INotificador _notificador;

        public BaseService(INotificador notificador)
        {
            _notificador = notificador;
        }

        protected void Notificar(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
            {
                Notificar(error.ErrorMessage);
            }
        }

        protected void Notificar(string menssagem)
        {
            _notificador.Handle(new Notificacao(menssagem));
        }

        protected bool ExecutarValidacao<TV, TE>(TV validacao, TE entidade) where TV : AbstractValidator<TE> where TE : Entity
        {
            var validator = validacao.Validate(entidade);

            if (validator.IsValid)
                return true;

            Notificar(validator);

            return false;
        }
    }
}
