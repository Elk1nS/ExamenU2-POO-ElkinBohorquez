using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ExamenU2_POO_ElkinBohorquez.Database.Entities
{
    [Table("detalle_planilla")]
    public class DetallePlanillaEntity
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        [ForeignKey(nameof(PlanillaId))]
        [Column("planilla_id")]
        public int PlanillaId { get; set; }

        [ForeignKey(nameof(EmpleadoId))]
        [Column("empleado")]
        public int EmpleadoId { get; set; }

        [Column("base_salary")]
        public decimal BaseSalary { get; set; }

        [Column("extra_hours")]
        public decimal HorasExtras { get; set; }

        [Column("amount_extra_hours")]
        public decimal MontoHorasExtra { get; set; }
        
        [Column("bonifications")]
        public decimal Bonificaciones { get; set; }

        [Column("deductions")]
        public decimal Deducciones { get; set; }

        [Column("net_salary")]
        public decimal SalarioNeto { get; set; }

        [Column("coments")]
        public string Comentarios { get; set; }
    }
}
