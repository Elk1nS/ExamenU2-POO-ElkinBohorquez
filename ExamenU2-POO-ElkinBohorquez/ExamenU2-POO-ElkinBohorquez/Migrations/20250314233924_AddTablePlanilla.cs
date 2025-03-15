using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExamenU2_POO_ElkinBohorquez.Migrations
{
    /// <inheritdoc />
    public partial class AddTablePlanilla : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "planilla",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    periodo = table.Column<string>(type: "TEXT", nullable: false),
                    date_creation = table.Column<DateTime>(type: "TEXT", nullable: false),
                    date_pay = table.Column<DateTime>(type: "TEXT", nullable: false),
                    state = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_planilla", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "planilla");
        }
    }
}
