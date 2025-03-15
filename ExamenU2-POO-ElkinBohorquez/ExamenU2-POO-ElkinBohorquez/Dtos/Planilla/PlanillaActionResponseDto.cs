using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ExamenU2_POO_ElkinBohorquez.Dtos.Planilla
{
    public class PlanillaActionResponseDto
    {
        public Guid Id { get; set; }

        public string Periodo { get; set; }

        public DateTime DateCreation { get; set; }

        public DateTime DatePay { get; set; }

        public string State { get; set; }
    }
}
