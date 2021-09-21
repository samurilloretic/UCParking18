using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UCP.App.Persistencia.Migrations
{
    public partial class Segunda : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_personas_Vehiculo_Vehiculo_1id",
                table: "personas");

            migrationBuilder.DropForeignKey(
                name: "FK_personas_Vehiculo_Vehiculo_2id",
                table: "personas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Vehiculo",
                table: "Vehiculo");

            migrationBuilder.RenameTable(
                name: "Vehiculo",
                newName: "vehiculos");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "personas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Parqueaderoid",
                table: "personas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "actividad",
                table: "personas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "autoriza",
                table: "personas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "cubiculo",
                table: "personas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "facultad",
                table: "personas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "oficina",
                table: "personas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "programa",
                table: "personas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "tarifaAdministrativo",
                table: "personas",
                type: "real",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "tarifaEstudiante",
                table: "personas",
                type: "real",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "tarifaProfesor",
                table: "personas",
                type: "real",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "tarifaVisitante",
                table: "personas",
                type: "real",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "unidad",
                table: "personas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_vehiculos",
                table: "vehiculos",
                column: "id");

            migrationBuilder.CreateTable(
                name: "parqueaderos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    direccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    horario = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    picoPlaca = table.Column<int>(type: "int", nullable: false),
                    numeroPuestos = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_parqueaderos", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "puestos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    numero = table.Column<int>(type: "int", nullable: false),
                    estado = table.Column<int>(type: "int", nullable: false),
                    tipoVehiculo = table.Column<int>(type: "int", nullable: false),
                    Parqueaderoid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_puestos", x => x.id);
                    table.ForeignKey(
                        name: "FK_puestos_parqueaderos_Parqueaderoid",
                        column: x => x.Parqueaderoid,
                        principalTable: "parqueaderos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "transacciones",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    horaIngreso = table.Column<DateTime>(type: "datetime2", nullable: false),
                    horaSalida = table.Column<DateTime>(type: "datetime2", nullable: false),
                    vehiculoid = table.Column<int>(type: "int", nullable: true),
                    personaid = table.Column<int>(type: "int", nullable: true),
                    Parqueaderoid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_transacciones", x => x.id);
                    table.ForeignKey(
                        name: "FK_transacciones_parqueaderos_Parqueaderoid",
                        column: x => x.Parqueaderoid,
                        principalTable: "parqueaderos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_transacciones_personas_personaid",
                        column: x => x.personaid,
                        principalTable: "personas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_transacciones_vehiculos_vehiculoid",
                        column: x => x.vehiculoid,
                        principalTable: "vehiculos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_personas_Parqueaderoid",
                table: "personas",
                column: "Parqueaderoid");

            migrationBuilder.CreateIndex(
                name: "IX_puestos_Parqueaderoid",
                table: "puestos",
                column: "Parqueaderoid");

            migrationBuilder.CreateIndex(
                name: "IX_transacciones_Parqueaderoid",
                table: "transacciones",
                column: "Parqueaderoid");

            migrationBuilder.CreateIndex(
                name: "IX_transacciones_personaid",
                table: "transacciones",
                column: "personaid");

            migrationBuilder.CreateIndex(
                name: "IX_transacciones_vehiculoid",
                table: "transacciones",
                column: "vehiculoid");

            migrationBuilder.AddForeignKey(
                name: "FK_personas_parqueaderos_Parqueaderoid",
                table: "personas",
                column: "Parqueaderoid",
                principalTable: "parqueaderos",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_personas_vehiculos_Vehiculo_1id",
                table: "personas",
                column: "Vehiculo_1id",
                principalTable: "vehiculos",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_personas_vehiculos_Vehiculo_2id",
                table: "personas",
                column: "Vehiculo_2id",
                principalTable: "vehiculos",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_personas_parqueaderos_Parqueaderoid",
                table: "personas");

            migrationBuilder.DropForeignKey(
                name: "FK_personas_vehiculos_Vehiculo_1id",
                table: "personas");

            migrationBuilder.DropForeignKey(
                name: "FK_personas_vehiculos_Vehiculo_2id",
                table: "personas");

            migrationBuilder.DropTable(
                name: "puestos");

            migrationBuilder.DropTable(
                name: "transacciones");

            migrationBuilder.DropTable(
                name: "parqueaderos");

            migrationBuilder.DropIndex(
                name: "IX_personas_Parqueaderoid",
                table: "personas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_vehiculos",
                table: "vehiculos");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "personas");

            migrationBuilder.DropColumn(
                name: "Parqueaderoid",
                table: "personas");

            migrationBuilder.DropColumn(
                name: "actividad",
                table: "personas");

            migrationBuilder.DropColumn(
                name: "autoriza",
                table: "personas");

            migrationBuilder.DropColumn(
                name: "cubiculo",
                table: "personas");

            migrationBuilder.DropColumn(
                name: "facultad",
                table: "personas");

            migrationBuilder.DropColumn(
                name: "oficina",
                table: "personas");

            migrationBuilder.DropColumn(
                name: "programa",
                table: "personas");

            migrationBuilder.DropColumn(
                name: "tarifaAdministrativo",
                table: "personas");

            migrationBuilder.DropColumn(
                name: "tarifaEstudiante",
                table: "personas");

            migrationBuilder.DropColumn(
                name: "tarifaProfesor",
                table: "personas");

            migrationBuilder.DropColumn(
                name: "tarifaVisitante",
                table: "personas");

            migrationBuilder.DropColumn(
                name: "unidad",
                table: "personas");

            migrationBuilder.RenameTable(
                name: "vehiculos",
                newName: "Vehiculo");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Vehiculo",
                table: "Vehiculo",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_personas_Vehiculo_Vehiculo_1id",
                table: "personas",
                column: "Vehiculo_1id",
                principalTable: "Vehiculo",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_personas_Vehiculo_Vehiculo_2id",
                table: "personas",
                column: "Vehiculo_2id",
                principalTable: "Vehiculo",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
