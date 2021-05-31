using FluentValidation;
using System;

namespace RS.SorteOnline.Agenda.Domain.Validations
{
    public abstract class AgendaValidation<T> : AbstractValidator<T>
    {
    }
}
