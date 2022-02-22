using Microsoft.VisualStudio.TestTools.UnitTesting;
using MinhaAgendaMinhaVida.Models;
using MinhaAgendaMinhaVida.Services;
using System;

namespace AgendamentoTests
{
    [TestClass]
    public class TestesDeAgendamento
    {
        [TestMethod]
        public void TesteAgendamentoAntesDeAgora()
        {
            var agendamento = new Agendamento { Data = DateTime.Now.AddMinutes(-1), Descricao = "teste" };
            var servicoDeAgenda = new ServicoDeAgenda();

            try
            {
                servicoDeAgenda.Adicionar(10, agendamento);
            }
            catch (Exception ex)
            {
                StringAssert.Equals(ex.Message, "O agendamento n�o pode ser antes de agora.");
            }
        }

        [TestMethod]
        public void TesteAgendamentoSemDescricao()
        {
            var agendamento = new Agendamento { Data = DateTime.Now.AddMinutes(10), Descricao = "" };
            var servicoDeAgenda = new ServicoDeAgenda();

            try
            {
                servicoDeAgenda.Adicionar(10, agendamento);
            }
            catch (Exception ex)
            {
                StringAssert.Equals(ex.Message, "A descri��o precisa ser preenchida.");
            }
        }

        [TestMethod]
        public void TesteAgendamentoComDescricaoMaiorQuePermitido()
        {
            var agendamento = new Agendamento { Data = DateTime.Now.AddMinutes(10), Descricao = "Lorem ipsum dolor sit amet, consectetur 41" };
            var servicoDeAgenda = new ServicoDeAgenda();

            try
            {
                servicoDeAgenda.Adicionar(10, agendamento);
            }
            catch (Exception ex)
            {
                StringAssert.Equals(ex.Message, "A descri��o pode ter no m�ximo 40 caracteres.");
            }
        }
    }
}