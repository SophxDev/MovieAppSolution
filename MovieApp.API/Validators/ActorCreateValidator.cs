using FluentValidation;
using MovieApp.API.DTOs;

namespace MovieApp.API.Validators
{
    public class ActorCreateValidator :AbstractValidator<ActorCreateDto>
    {
        public ActorCreateValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("El nombre es obligatorio.")
                .MaximumLength(100).WithMessage("El nombre no debe tener más de 100 caracteres.");
            RuleFor(x => x.Biography)
                .NotEmpty().WithMessage("La biografía es obligatoria.")
                .MaximumLength(500).WithMessage("La biografía no debe tener más de 500 caracteres.");
            RuleFor(x => x.ImageUrl)
                .NotEmpty().WithMessage("La URL de imagen es obligatoria.")
                .Must(url => Uri.IsWellFormedUriString(url, UriKind.Absolute))
                .WithMessage("La URL de la imagen no es valida.");
        }
    }
}
