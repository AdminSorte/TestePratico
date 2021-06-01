using System;
using System.ComponentModel.DataAnnotations;

namespace API.ViewModels
{
    public class AtualizarViewModel
    {

        [Required(ErrorMessage = "O ID não pode tar vazio.")]
        [Range(1, int.MaxValue, ErrorMessage = "O ID deve ter no minimo 1 caracteres.")]
        public int Id { get; set; }

        [MinLength(3, ErrorMessage = "O titulo deve ter no minimo 3 caracteres")]
        [MaxLength(25, ErrorMessage = "O titulo deve ter no maximo 25 caracteres")]
        public string Titulo { get; set; }

        [MinLength(3, ErrorMessage = "O titulo deve ter no minimo 3 caracteres")]
        [MaxLength(100, ErrorMessage = "O titulo deve ter no maximo 100 caracteres")]
        public string Descricao { get; set; }

        [DataType(DataType.Date)]
        public DateTime Data { get; set; }
    }
}
