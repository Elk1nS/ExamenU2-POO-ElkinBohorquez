using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ExamenU2_POO_ElkinBohorquez.Dtos.DetallePlanilla
{
    public class DetallePlanillaDto
    {
        public Guid Id { get; set; }

        public int PlanillaId { get; set; }

        public int EmpleadoId { get; set; }

        public decimal BaseSalary { get; set; }

        public decimal HorasExtras { get; set; }

        public decimal MontoHorasExtra { get; set; }

        public decimal Bonificaciones { get; set; }

        public decimal Deducciones { get; set; }

        public decimal SalarioNeto { get; set; }

        public string Comentarios { get; set; }
    }
}
