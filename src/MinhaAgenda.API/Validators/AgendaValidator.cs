using FluentValidation;
using MinhaAgenda.API.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhaAgenda.API.Validators
{
    public class AgendaValidator : AbstractValidator<AgendaViewModel>
    {
        public AgendaValidator()
        {
            RuleFor(p => p.Titulo)
                .NotNull()
                .WithMessage("O campo {PropertyName} precisa ser fornecido")
                 .Length(1, 100).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(p => p.Descricao)
              .NotNull()
              .WithMessage("O campo {PropertyName} precisa ser fornecido")
               .Length(1, 100).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");
        }
    }
}
