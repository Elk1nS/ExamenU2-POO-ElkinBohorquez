using System.ComponentModel.DataAnnotations;

namespace ExamenU2_POO_ElkinBohorquez.Dtos.Empleados
{
    public class EmpleadoCreateDto
    {
        [Display(Name = "Nombres")]
        [Required(ErrorMessage = "El campo nombres es requerido")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "El campo {0} debe tener un minimo de de {2} y un maximo de {1} caracteres")]
        public string FirstName { get; set; }

        [Display(Name = "Apellidos")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "El campo {0} debe tener un minimo de de {2} y un maximo de {1} caracteres")]
        public string LastName { get; set; }

        [Display(Name = "Documento Nacional de Identidad")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(13, MinimumLength = 13, ErrorMessage = "El campo {0} debe tener un minimo de de {2} y un maximo de {1} caracteres")]
        public string DNI { get; set; }

    }
}
