using FluentValidation;

namespace ControleCinemas.Business.Models.Validations
{
    public class CinemaValidation : AbstractValidator<Cinema>
    {
        public CinemaValidation()
        {
            RuleFor(c => c.NomeEmpresa)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                 .Length(2, 100)
                    .WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(c => c.NomeFantasia)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                 .Length(2, 100)
                    .WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(c => c.Ingresso)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");

            RuleFor(c => c.Filmes)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");

            RuleFor(c => c.Endereco)
               .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");
        }
    }
}
