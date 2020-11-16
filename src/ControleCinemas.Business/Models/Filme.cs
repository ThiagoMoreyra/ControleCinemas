using System.Collections.Generic;

namespace ControleCinemas.Business.Models
{
    public class Filme : Entity
    {
        public string TituloPortugues { get; set; }
        public string TituloOriginal { get; set; }
        public int Duracao { get; set; }
        public string PaisOrigem { get; set; }
        public Genero Genero { get; set; }
        public Ator Ator { get; set; }
        public IEnumerable<Cinema> Cinemas { get; set; }
    }
}
