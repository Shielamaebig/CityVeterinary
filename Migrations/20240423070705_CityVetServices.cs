using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CityVeterinary.Migrations
{
    /// <inheritdoc />
    public partial class CityVetServices : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PetVaccines_Vaccinators_VaccinatorId",
                table: "PetVaccines");

            migrationBuilder.DropForeignKey(
                name: "FK_PetVaccines_Vaccines_VaccineId",
                table: "PetVaccines");

            migrationBuilder.DropForeignKey(
                name: "FK_PetVaccines_Veterinarians_VeterinarianId",
                table: "PetVaccines");

            migrationBuilder.AlterColumn<int>(
                name: "VeterinarianId",
                table: "PetVaccines",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "VaccineId",
                table: "PetVaccines",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "VaccinatorId",
                table: "PetVaccines",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "PetOwn",
                table: "PetVaccines",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ServicesId",
                table: "PetVaccines",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_PetVaccines_ServicesId",
                table: "PetVaccines",
                column: "ServicesId");

            migrationBuilder.AddForeignKey(
                name: "FK_PetVaccines_Services_ServicesId",
                table: "PetVaccines",
                column: "ServicesId",
                principalTable: "Services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PetVaccines_Vaccinators_VaccinatorId",
                table: "PetVaccines",
                column: "VaccinatorId",
                principalTable: "Vaccinators",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PetVaccines_Vaccines_VaccineId",
                table: "PetVaccines",
                column: "VaccineId",
                principalTable: "Vaccines",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PetVaccines_Veterinarians_VeterinarianId",
                table: "PetVaccines",
                column: "VeterinarianId",
                principalTable: "Veterinarians",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PetVaccines_Services_ServicesId",
                table: "PetVaccines");

            migrationBuilder.DropForeignKey(
                name: "FK_PetVaccines_Vaccinators_VaccinatorId",
                table: "PetVaccines");

            migrationBuilder.DropForeignKey(
                name: "FK_PetVaccines_Vaccines_VaccineId",
                table: "PetVaccines");

            migrationBuilder.DropForeignKey(
                name: "FK_PetVaccines_Veterinarians_VeterinarianId",
                table: "PetVaccines");

            migrationBuilder.DropIndex(
                name: "IX_PetVaccines_ServicesId",
                table: "PetVaccines");

            migrationBuilder.DropColumn(
                name: "PetOwn",
                table: "PetVaccines");

            migrationBuilder.DropColumn(
                name: "ServicesId",
                table: "PetVaccines");

            migrationBuilder.AlterColumn<int>(
                name: "VeterinarianId",
                table: "PetVaccines",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "VaccineId",
                table: "PetVaccines",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "VaccinatorId",
                table: "PetVaccines",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PetVaccines_Vaccinators_VaccinatorId",
                table: "PetVaccines",
                column: "VaccinatorId",
                principalTable: "Vaccinators",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PetVaccines_Vaccines_VaccineId",
                table: "PetVaccines",
                column: "VaccineId",
                principalTable: "Vaccines",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PetVaccines_Veterinarians_VeterinarianId",
                table: "PetVaccines",
                column: "VeterinarianId",
                principalTable: "Veterinarians",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
