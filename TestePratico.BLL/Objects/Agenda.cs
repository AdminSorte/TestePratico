using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL = TestePratico.DAL;

namespace TestePratico.BLL.Objects
{
    public class Agenda
    {
        private DAL.Objects.Agenda _objAgendaDAL;

        public Agenda()
        {
            _objAgendaDAL = new DAL.Objects.Agenda();
        }

        public bool Incluir(Model.Entity.Agenda Agenda)
        {
            try
            {
                if (String.IsNullOrEmpty(Agenda.Descricao))
                    throw new Exception("Descrição da agenda não informada!");

                Agenda.DataCadastro = DateTime.Now;

                return _objAgendaDAL.Incluir(Agenda);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool Alterar(Model.Entity.Agenda Agenda)
        {
            try
            {
                if(Agenda.ID == 0)
                    throw new Exception("ID da Agenda não informado!");

                if (String.IsNullOrEmpty(Agenda.Descricao))
                    throw new Exception("Descrição da agenda não informada!");

                Agenda.DataCadastro = DateTime.Now;

                return _objAgendaDAL.Alterar(Agenda);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool Excluir(Model.Entity.Agenda Agenda)
        {
            return _objAgendaDAL.Excluir(Agenda);
        }

        public Model.Entity.Agenda ObterAgenda(int id)
        {
            return _objAgendaDAL.ObterAgenda(id);
        }

        public List<Model.Entity.Agenda> ListarAgendas()
        {
            return _objAgendaDAL.ListarAgendas();
        }
    }
}