using System;
using System.Collections.Generic;

namespace ExceptionsDomain.Exceptions
{
    public class DomainExceptions : Exception
    {
        internal List<string> _errors;
        public IReadOnlyCollection<string> Errors => _errors;

        public DomainExceptions() { }

        public DomainExceptions(string mensagem , List<string> errors)
        {
            _errors = errors;
        }

        public DomainExceptions(string mensagem) : base(mensagem)
        {
        }

        public DomainExceptions(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
