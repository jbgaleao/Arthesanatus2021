
using FluentValidation;

namespace Arthesanatus2021.Business.Models.Receitas.Validations
{
    public class ReceitaValidation : AbstractValidator<Receita>
    {
        public ReceitaValidation()
        {
            RuleFor(r => r.Nome)
                .NotEmpty()
                .NotNull()
                .WithMessage("Informe o {PropertyName}")
                .MaximumLength(150);

            RuleFor(r => r.Descricao)
                .NotEmpty()
                .NotNull()
                .WithMessage("Informe a {PropertyName}")
                .MaximumLength(2000);

            RuleFor(r => r.Foto)
                .NotEmpty()
                .NotNull()
                .WithMessage("Informe o caminha da {PropertyName}")
                .MaximumLength(2000);

            //RuleFor(r => r.RevistaId)
            //    .NotEmpty()
            //    .NotNull()
            //    .WithMessage("Informe o {PropertyName}");
        }
    }
}
