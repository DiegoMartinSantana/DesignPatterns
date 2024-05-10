namespace DesignPatternAsp.Models.ViewModels
{
    public class TurnosViewModel
    {
        public int IdTurno { get; set; }
       public DateTime Fecha { get; set; }
        public int Duracion { get; set; }
        public int IdPaciente { get; set; }

        public int IdMedico { get; set; }
    }
}
