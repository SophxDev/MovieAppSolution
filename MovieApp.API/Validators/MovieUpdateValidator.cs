using FluentValidation;
using MovieApp.API.DTOs;

namespace MovieApp.API.Validators
{
    public class MovieUpdateValidator : AbstractValidator<MovieUpdateDto>
    {
        public MovieUpdateValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("El ID debe ser valido.");

            RuleFor(x => x.Title)
               .NotEmpty().WithMessage("El título es obligatorio.")
               .MaximumLength(100).WithMessage("El título no debe tener más de 100 caracteres.");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("La descripción es obligatoria.")
                .MaximumLength(500).WithMessage("La descripción no debe tener más de 500 caracteres.");

            RuleFor(x => x.ImageUrl)
                .NotEmpty().WithMessage("La URL de imagen es obligatoria.")
                .Must(uri => Uri.IsWellFormedUriString(uri, UriKind.Absolute))
                .WithMessage("Debe ser una URL válida.");

            /*RuleFor(x => x.Actors)
                .NotNull().WithMessage("La lista de actores no puede ser nula.")
                .Must(list => list.Count > 0).WithMessage("Debe haber al menos un actor.")
                .ForEach(actor =>
                    actor.NotEmpty().WithMessage("El nombre del actor no puede estar vacío."));*/
        }
    }
}
