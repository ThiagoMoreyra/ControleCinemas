using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ControleCinemas.Api.ViewModels
{
    public class GeneroViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(200, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Descricao { get; set; }
        public IEnumerable<FilmeViewModel> Filmes { get; set; }
    }
}