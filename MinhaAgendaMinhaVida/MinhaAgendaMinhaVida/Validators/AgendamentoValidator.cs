using FluentValidation;
using MinhaAgendaMinhaVida.Models;

namespace MinhaAgendaMinhaVida.Validators
{
    public class AgendamentoValidator : AbstractValidator<Agendamento>
    {
        public AgendamentoValidator()
        {
            RuleFor(agend => agend.Data)
                .NotEmpty().WithMessage("A data precisa ser informada.")
                .Must(data => data > DateTime.Now).WithMessage("O agendamento não pode ser antes de agora.");
            RuleFor(agend => agend.Descricao)
                .NotEmpty().WithMessage("A descrição precisa ser preenchida.")
                .MaximumLength(40).WithMessage("A descrição pode ter no máximo 40 caracteres.");
        }
    }
}
