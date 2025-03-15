using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExamenU2_POO_ElkinBohorquez.Database.Entities
{
    [Table("planilla")]
    public class PlanillaEntity
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        [Column("periodo")]
        [Required]
        public string Periodo { get; set; }

        [Column("date_creation")]
        public DateTime DateCreation { get; set; }

        [Column("date_pay")]
        public DateTime DatePay { get; set; }


        [Column("state")]
        public string State { get; set; }
    }
}
