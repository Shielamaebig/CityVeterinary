using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CityVeterinary.Migrations
{
    /// <inheritdoc />
    public partial class CityVetAddVaccintor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PetVaccines_Vaccinator_VaccinatorId",
                table: "PetVaccines");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Vaccinator",
                table: "Vaccinator");

            migrationBuilder.RenameTable(
                name: "Vaccinator",
                newName: "Vaccinators");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Vaccinators",
                table: "Vaccinators",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PetVaccines_Vaccinators_VaccinatorId",
                table: "PetVaccines",
                column: "VaccinatorId",
                principalTable: "Vaccinators",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PetVaccines_Vaccinators_VaccinatorId",
                table: "PetVaccines");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Vaccinators",
                table: "Vaccinators");

            migrationBuilder.RenameTable(
                name: "Vaccinators",
                newName: "Vaccinator");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Vaccinator",
                table: "Vaccinator",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PetVaccines_Vaccinator_VaccinatorId",
                table: "PetVaccines",
                column: "VaccinatorId",
                principalTable: "Vaccinator",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
