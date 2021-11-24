using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AgendaWebApi.Data.Dtos
{
    public class UpdateEventoDto
    {
        [Required]
        [MaxLength(200)]
        public string Descricao { get; set; }
        [Required]
        public string Periodo { get; set; }
        [Required]
        public DateTime Data { get; set; }
    }
}
