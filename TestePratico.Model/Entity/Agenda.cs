using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TestePratico.Model.Entity
{
    public class Agenda : Interface.IEntity
    {
        [Key]
        public int ID { get; set; }

        public string Descricao { get; set; }
    }
}
