using System;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using MinhaAgendaMinhaVida.Domain.Commands.Agenda;
using MinhaAgendaMinhaVida.Domain.Interfaces.Service;
using Xunit;

namespace MinhaAgendaMinhaVida.Test
{
    public class AgendaTest : BaseTest
    {
        private readonly IAgendaService _agendaService;
        private readonly IMapper _mapper;

        public AgendaTest()
        {
            _mapper = _serviceProvider.GetService<IMapper>();
            _agendaService = _serviceProvider.GetService<IAgendaService>();
        }

        [Fact]
        public void RetornarLista()
        {
            var command = new SelectAgendaCommand {Titulo = string.Empty};
            var result = _agendaService.List(command);
            Assert.NotEmpty(result);
        }

        [Theory]
        [InlineData(1)]
        public void RetornarAgenda(int id)
        {
            var result = _agendaService.View(id);
            Assert.NotNull(result);
        }

        [Fact]
        public void CriarAgenda()
        {
            var command = new InsertAgendaCommand
                {Descricao = "Teste Unitário", Data = DateTime.Now, Titulo = "Teste Unitário"};
            var result = _agendaService.Add(command);
            Assert.NotEqual(result, 0);
        }

        [Theory]
        [InlineData(1)]
        public void ApagarAgenda(int id)
        {
            var result = _agendaService.Delete(id);
            Assert.Equal(result, true);
        }

        [Fact]
        public void AlterarAgenda()
        {
            var command = new UpdateAgendaCommand
                {Id = 1, Descricao = "Teste Unitário", Data = DateTime.Now, Titulo = "Teste Unitário"};
            var result = _agendaService.Edit(command);
            Assert.Equal(result, true);
        }
    }
}