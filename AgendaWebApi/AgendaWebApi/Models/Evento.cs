using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AgendaWebApi.Models
{
    public class Evento
    {
        [Required]
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(200)]
        public  string Descricao { get; set; }
        [Required]
        public  string Periodo { get; set; }
        [Required]
        public  DateTime Data { get; set; }
        


    }
}
