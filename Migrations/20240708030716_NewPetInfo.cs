using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CityVeterinary.Migrations
{
    /// <inheritdoc />
    public partial class NewPetInfo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PetInformations_Services_ServicesId",
                table: "PetInformations");

            migrationBuilder.DropForeignKey(
                name: "FK_PetInformations_Vaccinators_VaccinatorId",
                table: "PetInformations");

            migrationBuilder.DropForeignKey(
                name: "FK_PetInformations_Vaccines_VaccineId",
                table: "PetInformations");

            migrationBuilder.DropForeignKey(
                name: "FK_PetInformations_Veterinarians_VeterinarianId",
                table: "PetInformations");

            migrationBuilder.DropIndex(
                name: "IX_PetInformations_ServicesId",
                table: "PetInformations");

            migrationBuilder.DropIndex(
                name: "IX_PetInformations_VaccinatorId",
                table: "PetInformations");

            migrationBuilder.DropIndex(
                name: "IX_PetInformations_VaccineId",
                table: "PetInformations");

            migrationBuilder.DropIndex(
                name: "IX_PetInformations_VeterinarianId",
                table: "PetInformations");

            migrationBuilder.DropColumn(
                name: "DateVaxEnd",
                table: "PetInformations");

            migrationBuilder.DropColumn(
                name: "DateVaxStart",
                table: "PetInformations");

            migrationBuilder.DropColumn(
                name: "ServiceName",
                table: "PetInformations");

            migrationBuilder.DropColumn(
                name: "ServicesId",
                table: "PetInformations");

            migrationBuilder.DropColumn(
                name: "VaccinatorId",
                table: "PetInformations");

            migrationBuilder.DropColumn(
                name: "VaccinatorName",
                table: "PetInformations");

            migrationBuilder.DropColumn(
                name: "VaccineId",
                table: "PetInformations");

            migrationBuilder.DropColumn(
                name: "VaccineName",
                table: "PetInformations");

            migrationBuilder.DropColumn(
                name: "VeterinarianId",
                table: "PetInformations");

            migrationBuilder.DropColumn(
                name: "VeterinarianName",
                table: "PetInformations");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DateVaxEnd",
                table: "PetInformations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DateVaxStart",
                table: "PetInformations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ServiceName",
                table: "PetInformations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ServicesId",
                table: "PetInformations",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "VaccinatorId",
                table: "PetInformations",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VaccinatorName",
                table: "PetInformations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "VaccineId",
                table: "PetInformations",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VaccineName",
                table: "PetInformations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "VeterinarianId",
                table: "PetInformations",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VeterinarianName",
                table: "PetInformations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PetInformations_ServicesId",
                table: "PetInformations",
                column: "ServicesId");

            migrationBuilder.CreateIndex(
                name: "IX_PetInformations_VaccinatorId",
                table: "PetInformations",
                column: "VaccinatorId");

            migrationBuilder.CreateIndex(
                name: "IX_PetInformations_VaccineId",
                table: "PetInformations",
                column: "VaccineId");

            migrationBuilder.CreateIndex(
                name: "IX_PetInformations_VeterinarianId",
                table: "PetInformations",
                column: "VeterinarianId");

            migrationBuilder.AddForeignKey(
                name: "FK_PetInformations_Services_ServicesId",
                table: "PetInformations",
                column: "ServicesId",
                principalTable: "Services",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PetInformations_Vaccinators_VaccinatorId",
                table: "PetInformations",
                column: "VaccinatorId",
                principalTable: "Vaccinators",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PetInformations_Vaccines_VaccineId",
                table: "PetInformations",
                column: "VaccineId",
                principalTable: "Vaccines",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PetInformations_Veterinarians_VeterinarianId",
                table: "PetInformations",
                column: "VeterinarianId",
                principalTable: "Veterinarians",
                principalColumn: "Id");
        }
    }
}
