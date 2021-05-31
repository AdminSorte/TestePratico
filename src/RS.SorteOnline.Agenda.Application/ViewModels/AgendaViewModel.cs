using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RS.SorteOnline.Agenda.Application.ViewModels
{
    public class AgendaViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O Nome é obrigatório")]
        [MinLength(2)]
        [MaxLength(100)]
        [DisplayName("Nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O Valor de Venda é obrigatório")]
        [DisplayName("Valor de Venda")]
        public decimal ValorVenda { get; set; }

        [Required(ErrorMessage = "The BirthDate is Required")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        [DisplayName("Birth Date")]
        public DateTime BirthDate { get; set; }
    }
}
