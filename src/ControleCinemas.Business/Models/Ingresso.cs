namespace ControleCinemas.Business.Models
{
    public class Ingresso : Entity
    {
        public double Inteiro { get; set; }
        public double Senior { get; set; }
        public double ProfessorMunicipio { get; set; }
        public double Jovens { get; set; }
        public double Deficiente { get; set; }
        public double Estudante { get; set; }
        public double Meia { get; set; }
        public double Pipoca { get; set; }
        public double Refrigerante { get; set; }
        public Cinema Cinema { get; set; }
    }
}
