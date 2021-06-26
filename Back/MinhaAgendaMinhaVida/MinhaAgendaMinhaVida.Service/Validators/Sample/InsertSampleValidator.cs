using System;
using FluentValidation;
using MinhaAgendaMinhaVida.Domain.Commands.Sample;

namespace MinhaAgendaMinhaVida.Service.Validators.Sample
{
    public class InsertSampleValidator : AbstractValidator<InsertSampleCommand>
    {
        public InsertSampleValidator()
        {
            RuleFor(x => x)
                .NotNull()
                .OnAnyFailure(x => throw new ArgumentException("Can't found the object."));
        }
    }
}