using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ControleCinemas.Api.ViewModels
{
    public class CinemaViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(200, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string NomeEmpresa { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(200, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 10)]
        public string NomeFantasia { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(200, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 10)]
        public string Cnpj { get; set; }
        public EnderecoViewModel Endereco { get; set; }
        public IngressoViewModel Ingresso { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int Capacidade { get; set; }
        public IEnumerable<FilmeViewModel> Filmes { get; set; }
        public IEnumerable<SessaoViewModel> Sessoes { get; set; }
    }
}