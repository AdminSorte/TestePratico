using System;
using NUnit.Framework;

namespace TestePratico.Test
{
    [TestFixture]
    public class UnitTestAgenda
    {
        [Test]
        public void TestMethodIncluir()
        {
            var objAgendaBLL = new BLL.Objects.Agenda();

            var result = objAgendaBLL.Incluir(new Model.Entity.Agenda()
            {
                Descricao = "Agenda do Paulo"
            });

            if (!result)
                Assert.Fail();
        }
    }
}
