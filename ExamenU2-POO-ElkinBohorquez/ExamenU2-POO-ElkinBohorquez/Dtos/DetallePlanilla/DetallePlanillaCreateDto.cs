using System.ComponentModel.DataAnnotations;

namespace ExamenU2_POO_ElkinBohorquez.Dtos.DetallePlanilla
{
    public class DetallePlanillaCreateDto
    {
        [Display(Name = "Id")]
        [Required(ErrorMessage = "El campo Id es requerido")]
        [StringLength(13, MinimumLength = 13, ErrorMessage = "El campo {0} debe tener un minimo de de {2} y un maximo de {1} caracteres")]
        public int Id { get; set; }

        [Display(Name = "Id de Planilla")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "El campo {0} debe tener un minimo de de {2} y un maximo de {1} caracteres")]
        public string PlanillaId { get; set; }
    }
}
