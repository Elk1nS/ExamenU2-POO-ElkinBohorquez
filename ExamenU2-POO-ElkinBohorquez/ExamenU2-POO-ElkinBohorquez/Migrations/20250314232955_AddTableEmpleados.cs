using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExamenU2_POO_ElkinBohorquez.Migrations
{
    /// <inheritdoc />
    public partial class AddTableEmpleados : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "empleados",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    first_name = table.Column<string>(type: "TEXT", nullable: false),
                    last_name = table.Column<string>(type: "TEXT", nullable: false),
                    document = table.Column<string>(type: "TEXT", nullable: false),
                    date_contratation = table.Column<DateTime>(type: "TEXT", nullable: false),
                    departament = table.Column<string>(type: "TEXT", nullable: true),
                    work_station = table.Column<string>(type: "TEXT", nullable: true),
                    base_salary = table.Column<decimal>(type: "TEXT", nullable: false),
                    activo = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_empleados", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "empleados");
        }
    }
}
