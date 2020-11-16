using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ControleCinemas.Api.ViewModels
{
    public class FilmeViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(200, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string TituloPortugues { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(200, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string TituloOriginal { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int Duracao { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(200, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string PaisOrigem { get; set; }
        public GeneroViewModel Genero { get; set; }
        public AtorViewModel Ator { get; set; }
        public IEnumerable<CinemaViewModel> Cinemas { get; set; }
    }
}