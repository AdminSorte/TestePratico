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

                //.Matches(@"^((0[1-9]|[12]\d)\/(0[1-9]|1[0-2])|30\/(0[13-9]|1[0-2])|31\/(0[13578]|1[02]))\/\d{4}$ ou ^([0]?[1-9]|[1|2][0-9]|[3][0|1])[./-]([0]?[1-9]|[1][0-2])[./-]([0-9]{4}|[0-9]{2})$")
                .WithMessage("Insira a data em um formato valido");
               
        }

      
    }
}
