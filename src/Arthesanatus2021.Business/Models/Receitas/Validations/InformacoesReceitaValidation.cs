
using FluentValidation;

namespace Arthesanatus2021.Business.Models.Receitas.Validations
{
    public class InformacoesReceitaValidation : AbstractValidator<InformacoesReceita>
    {
        public InformacoesReceitaValidation()
        {
            RuleFor(inf => inf.NivelDificuldade)
                .NotEmpty()
                .NotNull()
                .WithMessage("Informe o {PropertyName}");
                

            RuleFor(inf => inf.Tamanho)
                .NotEmpty()
                .NotNull()
                .WithMessage("Informe a {PropertyName}")
                .GreaterThan(0)
                .WithMessage("O {PropertyName} deve ser maio que zero");


            RuleFor(inf => inf.OutrosMateriais)
                .NotEmpty()
                .NotNull()
                .WithMessage("O Campo {PropertyName} não deve ser nulo")
                .MaximumLength(1024)
                .WithMessage("O {PropertyName} deve ter no máximo 1024 caracteres");

        }
    }
}
