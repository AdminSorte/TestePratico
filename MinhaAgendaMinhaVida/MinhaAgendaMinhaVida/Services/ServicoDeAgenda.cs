using Microsoft.EntityFrameworkCore;
using MinhaAgendaMinhaVida.Data;
using MinhaAgendaMinhaVida.Models;
using MinhaAgendaMinhaVida.Services.Interfaces;
using MinhaAgendaMinhaVida.Validators;

namespace MinhaAgendaMinhaVida.Services
{
    public class ServicoDeAgenda : IServicoDeAgenda
    {
        public Agendamento Adicionar(int usuarioId, Agendamento agendamento)
        {
            try
            {
                ValideAgendamento(agendamento);

                using (var context = new Context())
                {
                    agendamento.UsuarioId = usuarioId;

                    var agend = context.Agendamentos.Add(agendamento);
                    context.SaveChanges();
                    return agend.Entity;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Agendamento Atualizar(Agendamento agendamento)
        {
            try
            {
                ValideAgendamento(agendamento);

                using (var context = new Context())
                {
                    var agendamentoDb = context.Agendamentos
                                            .AsNoTracking()
                                            .Where(agend => agend.UsuarioId == agendamento.UsuarioId && agend.Id == agendamento.Id)
                                            .FirstOrDefault();

                    if (agendamentoDb is null)
                        throw new Exception("Agendamento não encontrado");

                    context.Agendamentos.Update(agendamento);
                    context.SaveChanges();

                    return agendamento;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Agendamento ObterAgendamento(int usuarioId, int agendamentoId)
        {
            try
            {
                using (var context = new Context())
                {
                    var agendamento = context.Agendamentos
                                            .Where(agend => agend.UsuarioId == usuarioId && agend.Id == agendamentoId)
                                            .FirstOrDefault();

                    if (agendamento is null)
                        throw new Exception("Agendamento não encontrado");

                    return agendamento;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Agendamento> ObterAgendamentos(int usuarioId)
        {
            try
            {
                using (var context = new Context())
                {
                    var agendamentos = context.Agendamentos
                        .AsNoTracking()
                        .Where(agend => agend.Usuario.Id == usuarioId)
                        .OrderBy(agend => agend.Data)
                        .ToList();

                    return agendamentos;
                }
            }
            catch (Exception)
            {
                throw;
            }        
        }

        public List<Agendamento> ObterAgendamentos(int usuarioId, string texto)
        {
            if(string.IsNullOrWhiteSpace(texto))
                return ObterAgendamentos(usuarioId);

            try
            {
                using (var context = new Context())
                {
                    var agendamentos = context.Agendamentos
                        .AsNoTracking()
                        .Where(agend => agend.Usuario.Id == usuarioId && agend.Descricao.ToUpper().Contains(texto.ToUpper()))
                        .OrderBy(agend => agend.Data)
                        .ToList();

                    return agendamentos;
                }
            }
            catch (Exception)
            {
                throw;
            }        
        }

        public bool Remover(int usuarioId, int agendamentoId)
        {
            try
            {
                using (var context = new Context())
                {
                    var agendamento = context.Agendamentos
                                            .AsNoTracking()
                                            .Where(agend => agend.UsuarioId == usuarioId && agend.Id == agendamentoId)
                                            .FirstOrDefault();

                    if (agendamento is null)
                        throw new Exception("Agendamento não encontrado");

                    context.Agendamentos.Remove(agendamento);
                    context.SaveChanges();

                    return true;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void ValideAgendamento(Agendamento agendamento)
        {
            var agendamentoValidator = new AgendamentoValidator();

            var validacao = agendamentoValidator.Validate(agendamento);
            if (!validacao.IsValid)
                throw new Exception(String.Join(";\n", validacao.Errors.Select(x => x.ErrorMessage)));
        }
    }
}
