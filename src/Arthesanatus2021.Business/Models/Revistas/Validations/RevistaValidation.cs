using FluentValidation;

namespace Arthesanatus2021.Business.Models.Revistas.Validations
{
    public class RevistaValidation : AbstractValidator<Revista>
    {
        public RevistaValidation()
        {
            RuleFor(r => r.NumeroEdicao)
                .NotEmpty()
                .WithMessage("Informe o {PropertyName}")
                .NotEqual(0)
                .InclusiveBetween(1, 999)
                .WithMessage("O Valor do {PropertyName} deve estar entre 1 e 999}");

            RuleFor(r => r.MesEdicao)
                .NotEmpty()
                .WithMessage("Informe o {PropertyName}");

            RuleFor(r => r.AnoEdicao)
                .NotEmpty()
                .WithMessage("Informe o {PropertyName}")
                .InclusiveBetween(2018, 2030)
                .WithMessage("O Valor do {PropertyName} deve estar entre 2018 e 2030}");

            RuleFor(r => r.Tema)
                .NotEmpty()
                .WithMessage("Informe o {PropertyName}")
                .MaximumLength(150)
                .WithMessage("O Valor do {PropertyName} deve ser menor que {ComparisonValue}");

            RuleFor(r => r.Foto)
                .NotEmpty()
                .WithMessage("Informe o Caminho da {PropertyName}")
                .MaximumLength(500)
                .WithMessage("O Valor do {PropertyName} deve ser menor que {ComparisonValue}");
        }
    }
}
