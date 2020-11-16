using System.Collections.Generic;

namespace ControleCinemas.Business.Models
{
    public class Cinema: Entity
    {
        public string NomeEmpresa { get; set; }
        public string NomeFantasia { get; set; }
        public string Cnpj { get; set; }
        public Endereco Endereco { get; set; }
        public Ingresso Ingresso { get; set; }
        public int Capacidade { get; set; }
        public IEnumerable<Filme> Filmes { get; set; }
        public IEnumerable<Sessao> Sessoes { get; set; }
    }
}
