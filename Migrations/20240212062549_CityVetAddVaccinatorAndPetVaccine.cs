using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CityVeterinary.Migrations
{
    /// <inheritdoc />
    public partial class CityVetAddVaccinatorAndPetVaccine : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DateVaxEnd",
                table: "PetVaccines",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DateVaxStart",
                table: "PetVaccines",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PetInformationId",
                table: "PetVaccines",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "VaccinatorId",
                table: "PetVaccines",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "VaccineId",
                table: "PetVaccines",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "VeterinarianId",
                table: "PetVaccines",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Vaccinator",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateAdded = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vaccinator", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PetVaccines_PetInformationId",
                table: "PetVaccines",
                column: "PetInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_PetVaccines_VaccinatorId",
                table: "PetVaccines",
                column: "VaccinatorId");

            migrationBuilder.CreateIndex(
                name: "IX_PetVaccines_VaccineId",
                table: "PetVaccines",
                column: "VaccineId");

            migrationBuilder.CreateIndex(
                name: "IX_PetVaccines_VeterinarianId",
                table: "PetVaccines",
                column: "VeterinarianId");

            migrationBuilder.AddForeignKey(
                name: "FK_PetVaccines_PetInformations_PetInformationId",
                table: "PetVaccines",
                column: "PetInformationId",
                principalTable: "PetInformations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PetVaccines_Vaccinator_VaccinatorId",
                table: "PetVaccines",
                column: "VaccinatorId",
                principalTable: "Vaccinator",
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PetVaccines_PetInformations_PetInformationId",
                table: "PetVaccines");

            migrationBuilder.DropForeignKey(
                name: "FK_PetVaccines_Vaccinator_VaccinatorId",
                table: "PetVaccines");

            migrationBuilder.DropForeignKey(
                name: "FK_PetVaccines_Vaccines_VaccineId",
                table: "PetVaccines");

            migrationBuilder.DropForeignKey(
                name: "FK_PetVaccines_Veterinarians_VeterinarianId",
                table: "PetVaccines");

            migrationBuilder.DropTable(
                name: "Vaccinator");

            migrationBuilder.DropIndex(
                name: "IX_PetVaccines_PetInformationId",
                table: "PetVaccines");

            migrationBuilder.DropIndex(
                name: "IX_PetVaccines_VaccinatorId",
                table: "PetVaccines");

            migrationBuilder.DropIndex(
                name: "IX_PetVaccines_VaccineId",
                table: "PetVaccines");

            migrationBuilder.DropIndex(
                name: "IX_PetVaccines_VeterinarianId",
                table: "PetVaccines");

            migrationBuilder.DropColumn(
                name: "DateVaxEnd",
                table: "PetVaccines");

            migrationBuilder.DropColumn(
                name: "DateVaxStart",
                table: "PetVaccines");

            migrationBuilder.DropColumn(
                name: "PetInformationId",
                table: "PetVaccines");

            migrationBuilder.DropColumn(
                name: "VaccinatorId",
                table: "PetVaccines");

            migrationBuilder.DropColumn(
                name: "VaccineId",
                table: "PetVaccines");

            migrationBuilder.DropColumn(
                name: "VeterinarianId",
                table: "PetVaccines");
        }
    }
}
