using System.ComponentModel.DataAnnotations;

namespace DesignPatternAsp.Models.ViewModels
{
    public class MedicoViewModel
    {
        // en este caso todos los camposon requeridos

        //solo para ejemplificar no valido existencias en bd de id
        [Required]
        [Display(Name = "Codigo Identificatorio del Medico")]
        public int Id { get; set; }
    
        [Display(Name = "Especialidad")] // muestra en la vista esto . no el id xque es desconocido
        public int? IdEspecialidad { get; set; }

        [Display(Name = "Especialidad Nueva:")]
        public string? EspecialidadNueva { get; set; } 
        //no es requerida, pero da opcion a agregar una nueva especialidad

       
        [Display(Name = "Nombre del Medico")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Apellido del Medico")]
        public string Apellido { get; set; }

        [Required]
        [Display(Name = "Fecha de Nacimiento")]
        public DateOnly FechaNacimiento { get; set; }

        [Required]
        [Display(Name = "Fecha de Ingreso")]
        public DateOnly FechaIngreso { get; set; }
       
        [Required]
        [Display(Name = "Costo de la Consulta")]
        public decimal CostoConsulta { get; set; }
       
        [Required]
        [Display(Name = "Sexo del Medico ( M o F)")]
        public string Sexo { get; set; }


    }
}
