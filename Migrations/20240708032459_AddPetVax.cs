using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CityVeterinary.Migrations
{
    /// <inheritdoc />
    public partial class AddPetVax : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PetVaccines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateAdded = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PetInformationId = table.Column<int>(type: "int", nullable: false),
                    PetName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Powner = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PetOwn = table.Column<int>(type: "int", nullable: true),
                    DateVaccinated = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VaccineId = table.Column<int>(type: "int", nullable: true),
                    VaccineName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VeterinarianId = table.Column<int>(type: "int", nullable: true),
                    VeterinarianName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VaccinatorId = table.Column<int>(type: "int", nullable: true),
                    VaccinatorName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ServicesId = table.Column<int>(type: "int", nullable: true),
                    ServiceName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PetVaccines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PetVaccines_PetInformations_PetInformationId",
                        column: x => x.PetInformationId,
                        principalTable: "PetInformations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PetVaccines_Services_ServicesId",
                        column: x => x.ServicesId,
                        principalTable: "Services",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PetVaccines_Vaccinators_VaccinatorId",
                        column: x => x.VaccinatorId,
                        principalTable: "Vaccinators",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PetVaccines_Vaccines_VaccineId",
                        column: x => x.VaccineId,
                        principalTable: "Vaccines",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PetVaccines_Veterinarians_VeterinarianId",
                        column: x => x.VeterinarianId,
                        principalTable: "Veterinarians",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_PetVaccines_PetInformationId",
                table: "PetVaccines",
                column: "PetInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_PetVaccines_ServicesId",
                table: "PetVaccines",
                column: "ServicesId");

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PetVaccines");
        }
    }
}
