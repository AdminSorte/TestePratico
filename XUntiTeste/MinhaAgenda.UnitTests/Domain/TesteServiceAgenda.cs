using MinhaAgenda.Domain.Interfaces;
using MinhaAgenda.Domain.Models;
using MinhaAgenda.Domain.Service;
using Moq;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace MinhaAgenda.UnitTests
{
    public class TesteServiceAgenda
    {
        private readonly IAgendaRepository _agendaRepository;
        private readonly AgendaService _agendaService;

        private readonly Agenda _agenda;
        public TesteServiceAgenda()
        {
            _agendaRepository = Substitute.For<IAgendaRepository>();
            _agendaService = new AgendaService(_agendaRepository);
            _agenda = new Agenda("Teste 1", "Vai da certo", DateTime.Now) { Id = 1 };
        }


        [Fact]
        public async Task BuscaAgendaComSucessoTrue()
        {
            //arrange
            Agenda agenda = _agenda;
       
          
            //Act
            var AgendaPorId =   _agendaService.ObterPorId(_agenda.Id)
                .Returns(agenda);

            // Assert

            Assert.NotNull(AgendaPorId);
        }


        [Fact]
        public void  TesteAtualizaAgendasComSucesso()
        {

            //arrange
            Agenda agenda = _agenda;



            //Act
            var result = _agendaService.TesteAtualizaAgendasComRegras(agenda);

            // Assert

            Assert.True(result);
        }



        [Fact]
        public void TesteAtualizaAgendasComFalse()
        {

            //arrange
            Agenda agenda = new Agenda("Teste 2", "Vai da certo", new System.DateTime(1996, 6, 3, 22, 15, 0)) { Id = 2 };



            //Act
            var result = _agendaService.TesteAtualizaAgendasComRegras(agenda);

            // Assert

            Assert.False(result);
        }




    }
}
