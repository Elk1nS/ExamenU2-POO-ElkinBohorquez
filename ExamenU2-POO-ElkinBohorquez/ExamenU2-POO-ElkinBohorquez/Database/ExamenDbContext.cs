using ExamenU2_POO_ElkinBohorquez.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace ExamenU2_POO_ElkinBohorquez.Database
{
    public class ExamenDbContext : DbContext
    {
        public ExamenDbContext(DbContextOptions options) : base(options) 
        { 
        }

        public DbSet<EmpleadoEntity> Empleados { get; set; }

        public DbSet<PlanillaEntity> Planilla { get; set; }

        public DbSet<DetallePlanillaEntity> DetallePlanilla { get; set; }
    }
}
