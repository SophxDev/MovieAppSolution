using FluentValidation;
using MovieApp.API.DTOs;

namespace MovieApp.API.Validators
{
    public class MovieCreateValidator : AbstractValidator<MovieCreateDto>
    {
        public MovieCreateValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("El titulo es obligatorio.")
                .MaximumLength(100).WithMessage("El titulo no debe tener más de 100 caracteres.");

            RuleFor(x => x.Description).NotEmpty()
                .NotEmpty().WithMessage("La descripción es obligatoria.")
                .MaximumLength(500).WithMessage("La descripción no deber tener más de 500 caracteres.");

            RuleFor(x => x.ImageUrl)
                .NotEmpty().WithMessage("La URL de imagen es obligatoria.")
                .Must(url => Uri.IsWellFormedUriString(url, UriKind.Absolute))
                .WithMessage("La URL de la imagen no es valida.");
            /*
            RuleFor(x => x.Actors)
                .NotNull().WithMessage("La lista de actores no puede estar vacia")
                .Must(list => list.Count > 0).WithMessage("Debe tener al menos un actor.")
                .ForEach(actor =>
                    actor.NotEmpty().WithMessage("El nombre del actor no puede estar vacio");
            */
        }
        
    }
}
