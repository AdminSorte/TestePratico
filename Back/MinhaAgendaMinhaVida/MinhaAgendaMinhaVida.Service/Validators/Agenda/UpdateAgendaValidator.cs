using System;
using FluentValidation;
using MinhaAgendaMinhaVida.Domain.Commands.Agenda;

namespace MinhaAgendaMinhaVida.Service.Validators.Agenda
{
    public class UpdateAgendaValidator : AbstractValidator<UpdateAgendaCommand>
    {
        public UpdateAgendaValidator()
        {
            RuleFor(x => x)
                .NotNull()
                .OnAnyFailure(x => { throw new ArgumentException("Objeto não encontrado."); });

            RuleFor(x => x.Titulo)
                .NotEmpty()
                .WithMessage("Título obrigatório.");

            RuleFor(x => x.Descricao)
                .NotEmpty()
                .WithMessage("Descrição obrigatória.");

            RuleFor(x => x.Data)
                .NotEmpty()
                .NotNull()
                .WithMessage("Data obrigatória.");
        }
    }
}