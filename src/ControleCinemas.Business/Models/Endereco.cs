namespace ControleCinemas.Business.Models
{
    public class Endereco : Entity
    {
        public string Logradouro { get; set; }
        public string Bairro { get; set; }
        public string Municipio { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }
        public Cinema Cinema { get; set; }
    }
}