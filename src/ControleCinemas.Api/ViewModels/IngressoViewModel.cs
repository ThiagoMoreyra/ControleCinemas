using System;
using System.ComponentModel.DataAnnotations;

namespace ControleCinemas.Api.ViewModels
{
    public class IngressoViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public double Inteiro { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public double Senior { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public double ProfessorMunicipio { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public double Jovens { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public double Deficiente { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public double Estudante { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public double Meia { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public double Pipoca { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public double Refrigerante { get; set; }

        public CinemaViewModel Cinema { get; set; }
    }
}