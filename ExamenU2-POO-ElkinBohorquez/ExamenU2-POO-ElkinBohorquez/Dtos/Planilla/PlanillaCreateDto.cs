using System.ComponentModel.DataAnnotations;

namespace ExamenU2_POO_ElkinBohorquez.Dtos.Planilla
{
    public class PlanillaCreateDto
    {
        [Display(Name = "Periodo")]
        [Required(ErrorMessage = "El campo estado es requerido")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "El campo {0} debe tener un minimo de de {2} y un maximo de {1} caracteres")]
        public string Periodo { get; set; }

        [Display(Name = "Estado")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "El campo {0} debe tener un minimo de de {2} y un maximo de {1} caracteres")]
        public string State { get; set; }
    }
}
