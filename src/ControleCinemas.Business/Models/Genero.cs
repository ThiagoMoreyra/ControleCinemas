using System.Collections.Generic;

namespace ControleCinemas.Business.Models
{
    public class Genero : Entity
    {
        public string Descricao { get; set; }
        public IEnumerable<Filme> Filmes { get; set; }
    }
}
