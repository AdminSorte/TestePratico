using System;
using FluentValidation;

namespace MinhaAgendaMinhaVida.Service.Services
{
    public class BaseService
    {
        internal void Validate<T>(T obj, AbstractValidator<T> validator)
        {
            if (obj.Equals(null))
                throw new Exception("Objeto inválido!");

            validator.ValidateAndThrow(obj);
        }
    }
}