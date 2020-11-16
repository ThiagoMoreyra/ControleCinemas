using System.Collections.Generic;

namespace ControleCinemas.Business.Models
{
    public class Ator : Entity
    {
        public int Idade { get; set; }
        public string Nome { get; set; }
        public bool Diretor { get; set; }
        public string Nacionalidade { get; set; }
        public IEnumerable<Filme> Filmes { get; set; }
    }
}
