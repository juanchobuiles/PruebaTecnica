using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.UseCases.Users.Commands.CreateUser
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(c => c.Nombre)
                .NotEmpty().WithMessage("Nombre no puede estar en blanco")
                .MaximumLength(50).WithMessage("Nombre no puede superar los 50 caracteres");
            RuleFor(x => x.Email)
           .NotEmpty().WithMessage("El correo electrónico es obligatorio.")
           .EmailAddress().WithMessage("Ingrese una dirección de correo electrónico válida.");
           RuleFor(x => x.Edad)
            .NotEmpty().WithMessage("La edad es obligatoria.")
            .InclusiveBetween(18, 99).WithMessage("La edad debe estar entre 18 y 99 años.");
        }
    }
}
