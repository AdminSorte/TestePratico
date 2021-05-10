using MinhaAgenda.Domain.Interfaces;
using MinhaAgenda.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinhaAgenda.Domain.Service
{
    public class AgendaService : IAgendaService
    {
        private readonly IAgendaRepository _agendaRepository;
        public AgendaService(IAgendaRepository agendaRepository)
        {
            _agendaRepository = agendaRepository;
        }
        public async Task<Agenda> ObterPorId(int id)
        {

            return await _agendaRepository.ObterPorId(id);
        }

        public bool TesteAtualizaAgendasComRegras(Agenda agenda)
        {

            //Regra que permite alteração em  1 dia
            if ((DateTime.Now - agenda.DataAgedamento).Days > 1)
            {
                return false;
            }

            return true;

        }

     
    }
}
