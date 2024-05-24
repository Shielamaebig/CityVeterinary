using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CityVeterinary.Migrations
{
    /// <inheritdoc />
    public partial class CityVetAddAppointments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Appointments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateAdded = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BaranggayId = table.Column<int>(type: "int", nullable: false),
                    OwnerImagepath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OwnerFileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PetName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Markings = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PetTypeId = table.Column<int>(type: "int", nullable: true),
                    PetDateOfBirth = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BreedTypeId = table.Column<int>(type: "int", nullable: false),
                    PetImgPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PetFileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AppointmentDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AppointmentTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UniqueCode = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Appointments_Baranggays_BaranggayId",
                        column: x => x.BaranggayId,
                        principalTable: "Baranggays",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Appointments_BreedTypes_BreedTypeId",
                        column: x => x.BreedTypeId,
                        principalTable: "BreedTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Appointments_PetTypes_PetTypeId",
                        column: x => x.PetTypeId,
                        principalTable: "PetTypes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_BaranggayId",
                table: "Appointments",
                column: "BaranggayId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_BreedTypeId",
                table: "Appointments",
                column: "BreedTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_PetTypeId",
                table: "Appointments",
                column: "PetTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Appointments");
        }
    }
}
