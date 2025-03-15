namespace ExamenU2_POO_ElkinBohorquez.Dtos.Empleados
{
    public class EmpleadoDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Document { get; set; }
        public DateTime DateContratation { get; set; }
        public string Departament { get; set; }
        public string WorkStation { get; set; }
        public decimal BaseSalary { get; set; }
        public bool Activo { get; set; }
    }
}
