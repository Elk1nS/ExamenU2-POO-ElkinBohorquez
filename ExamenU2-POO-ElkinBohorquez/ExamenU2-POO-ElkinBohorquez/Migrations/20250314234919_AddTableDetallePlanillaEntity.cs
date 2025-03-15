using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExamenU2_POO_ElkinBohorquez.Migrations
{
    /// <inheritdoc />
    public partial class AddTableDetallePlanillaEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "detalle_planilla",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    planilla_id = table.Column<int>(type: "INTEGER", nullable: false),
                    empleado = table.Column<int>(type: "INTEGER", nullable: false),
                    base_salary = table.Column<decimal>(type: "TEXT", nullable: false),
                    extra_hours = table.Column<decimal>(type: "TEXT", nullable: false),
                    amount_extra_hours = table.Column<decimal>(type: "TEXT", nullable: false),
                    bonifications = table.Column<decimal>(type: "TEXT", nullable: false),
                    deductions = table.Column<decimal>(type: "TEXT", nullable: false),
                    net_salary = table.Column<decimal>(type: "TEXT", nullable: false),
                    coments = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_detalle_planilla", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "detalle_planilla");
        }
    }
}
