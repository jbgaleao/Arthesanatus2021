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
                .InclusiveBetween(1, 999);

            RuleFor(r => r.MesEdicao)
                .NotEmpty()
                .WithMessage("Informe o {PropertyName}");

            RuleFor(r => r.AnoEdicao)
                .NotEmpty()
                .WithMessage("Informe o {PropertyName}");

            RuleFor(r => r.Tema)
                .NotEmpty()
                .WithMessage("Informe o {PropertyName}")
                .MaximumLength(150);

            RuleFor(r => r.Foto)
                .NotEmpty()
                .WithMessage("Informe o Caminho da {PropertyName}")
                .MaximumLength(500);
        }
    }
}
