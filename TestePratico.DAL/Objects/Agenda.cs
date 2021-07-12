using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestePratico.DAL.Objects
{
    public class Agenda
    {
        public bool Incluir(Model.Entity.Agenda Agenda)
        {
            using (var db = new Context.TestePraticoContext())
            {
                using (var repo = new Repository.Repository(db))
                {
                    repo.Add(Agenda);
                    return repo.Save() > 0;
                }
            }
        }

        public bool Alterar(Model.Entity.Agenda Agenda)
        {
            using (var db = new Context.TestePraticoContext())
            {
                using (var repo = new Repository.Repository(db))
                {
                    repo.Update(Agenda);
                    return repo.Save() > 0;
                }
            }
        }

        public bool Excluir(Model.Entity.Agenda Agenda)
        {
            using (var db = new Context.TestePraticoContext())
            {
                using (var repo = new Repository.Repository(db))
                {
                    repo.Remove(Agenda);
                    return repo.Save() > 0;
                }
            }
        }

        public Model.Entity.Agenda ObterAgenda(int id)
        {
            using (var db = new Context.TestePraticoContext())
            {
                using (var repo = new Repository.Repository(db))
                {
                    return repo.Get<Model.Entity.Agenda>(id);
                }
            }
        }

        public List<Model.Entity.Agenda> ListarAgendas()
        {
            using (var db = new Context.TestePraticoContext())
            {
                using (var repo = new Repository.Repository(db))
                {
                    return repo.Query<Model.Entity.Agenda>().ToList();
                }
            }
        }
    }
}
