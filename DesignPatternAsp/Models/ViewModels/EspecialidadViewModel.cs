using System.ComponentModel.DataAnnotations;

namespace DesignPatternAsp.Models.ViewModels
{
    public class EspecialidadViewModel
    {
        //USO DE DATAANOTATION

        //en mi bd no son autogenerados.
        [Required(ErrorMessage = "El campo Id es requerido")]
        [Display( Name = "Id de la Especialidad")]
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo Nombre es requerido")]
        [Display( Name = "Nombre de la Especialidad")]
        public string Nombre { get; set; }
        
    }
}
