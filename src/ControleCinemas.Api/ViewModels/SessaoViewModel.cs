using System;

namespace ControleCinemas.Api.ViewModels
{
    public class SessaoViewModel
    {
        public DateTime DataSessao { get; set; }
        public int HoraSessao { get; set; }
        public int PublicoSessao { get; set; }
        public CinemaViewModel Cinema { get; set; }
    }
}