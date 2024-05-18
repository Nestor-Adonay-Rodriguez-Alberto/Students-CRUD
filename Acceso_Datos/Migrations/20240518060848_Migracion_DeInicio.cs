using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Acceso_Datos.Migrations
{
    public partial class Migracion_DeInicio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id_Rol = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id_Rol);
                });

            migrationBuilder.CreateTable(
                name: "Profesores",
                columns: table => new
                {
                    Id_Profesor = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GradoAcademico = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sueldo = table.Column<double>(type: "float", nullable: false),
                    Aula = table.Column<int>(type: "int", nullable: false),
                    Fotografia = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    IdRolEnProfesor = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profesores", x => x.Id_Profesor);
                    table.ForeignKey(
                        name: "FK_Profesores_Roles_IdRolEnProfesor",
                        column: x => x.IdRolEnProfesor,
                        principalTable: "Roles",
                        principalColumn: "Id_Rol",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Materias",
                columns: table => new
                {
                    Id_Materia = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Horario = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    IdProfesorEnMateria = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materias", x => x.Id_Materia);
                    table.ForeignKey(
                        name: "FK_Materias_Profesores_IdProfesorEnMateria",
                        column: x => x.IdProfesorEnMateria,
                        principalTable: "Profesores",
                        principalColumn: "Id_Profesor",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Estudiantes",
                columns: table => new
                {
                    Id_Estudiante = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GradoAcademico = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdMateriaEnEstudiante = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estudiantes", x => x.Id_Estudiante);
                    table.ForeignKey(
                        name: "FK_Estudiantes_Materias_IdMateriaEnEstudiante",
                        column: x => x.IdMateriaEnEstudiante,
                        principalTable: "Materias",
                        principalColumn: "Id_Materia",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Estudiantes_IdMateriaEnEstudiante",
                table: "Estudiantes",
                column: "IdMateriaEnEstudiante");

            migrationBuilder.CreateIndex(
                name: "IX_Materias_IdProfesorEnMateria",
                table: "Materias",
                column: "IdProfesorEnMateria");

            migrationBuilder.CreateIndex(
                name: "IX_Profesores_IdRolEnProfesor",
                table: "Profesores",
                column: "IdRolEnProfesor");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Estudiantes");

            migrationBuilder.DropTable(
                name: "Materias");

            migrationBuilder.DropTable(
                name: "Profesores");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
