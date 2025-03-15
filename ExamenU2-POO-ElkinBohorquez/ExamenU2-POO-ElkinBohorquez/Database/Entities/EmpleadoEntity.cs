using ExamenU2_POO_ElkinBohorquez.Database.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExamenU2_POO_ElkinBohorquez.Database.Entities
{
    [Table("empleados")]

    public class EmpleadoEntity
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        [Column("first_name")]
        [Required]
        public string FirstName { get; set; }

        [Column("last_name")]
        [Required]
        public string LastName { get; set; }

        [Column("document")]
        [Required]
        public string Document { get; set; }

        [Column("date_contratation")]
        public DateTime DateContratation { get; set; }

        [Column("departament")]
        public string Departament { get; set; }

        [Column("work_station")]
        public string WorkStation { get; set; }

        [Column("base_salary")]
        public decimal BaseSalary { get; set; }

        [Column("activo")]
        public bool Activo { get; set; }
    }
}
