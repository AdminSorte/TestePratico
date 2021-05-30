using Domain.Entities;
using FluentValidation;
using System;

namespace Domain.Validacoes
{
    public class ValidacaoAgenda : AbstractValidator<Agenda>
    {
        public ValidacaoAgenda()
        {
            RuleFor(x => x)
                .NotEmpty()
                .WithMessage("A agenda não deve estar vazia")

                .NotNull()
                .WithMessage("A  agenda nao pode ser nula");

            RuleFor(x => x.Titulo)
                .NotEmpty()
                .WithMessage("O tilulo não pode estar vazio.")

                .MinimumLength(3)
                .WithMessage("O titulo deve ter no minimo 3 caracteres!.");

            RuleFor(x => x.Descricao)
              .MaximumLength(200)
              .WithMessage("A descrição deve ter no Maximo 200 caracteres!.");

            RuleFor(x => x.Data.ToString())
                .NotEmpty()
                .WithMessage("Insira uma data!")

                .Matches(@"^(?:(?:31(\/|-|\.)(?:0?[13578]|1[02]))\1|(?:(?:29|30)(\/|-|\.)(?:0?[13-9]|1[0-2])\2))(?:(?:1[6-9]|[2-9]\d)?\d{2})
                    $|^(?:29(\/|-|\.)0?2\3(?:(?:(?:1[6-9]|[2-9]\d)?(?:0[48]|[2468][048]|[13579][26])|(?:(?:16|[2468][048]|[3579][26])00))))$|^(?:0?[1-9]|1\d|2[0-8])(\/|-|\.)
                    (?:(?:0?[1-9])|(?:1[0-2]))\4(?:(?:1[6-9]|[2-9]\d)?\d{2})$")
                .WithMessage("Insira a data em um formato valido");
               
        }

      
    }
}
