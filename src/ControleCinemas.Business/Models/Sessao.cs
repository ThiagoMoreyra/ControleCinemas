using System;

namespace ControleCinemas.Business.Models
{
    public class Sessao : Entity
    {
        public DateTime DataSessao { get; set; }
        public int HoraSessao { get; set; }
        public int PublicoSessao { get; set; }
        public Cinema Cinema { get; set; }
    }
}
