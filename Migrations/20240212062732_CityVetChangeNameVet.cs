using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CityVeterinary.Migrations
{
    /// <inheritdoc />
    public partial class CityVetChangeNameVet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Vaccinator",
                table: "Veterinarians",
                newName: "VetName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "VetName",
                table: "Veterinarians",
                newName: "Vaccinator");
        }
    }
}
