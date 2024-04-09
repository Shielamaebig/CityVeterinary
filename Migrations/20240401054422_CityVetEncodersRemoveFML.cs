using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CityVeterinary.Migrations
{
    /// <inheritdoc />
    public partial class CityVetEncodersRemoveFML : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "CityVetEncoders");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "CityVetEncoders");

            migrationBuilder.DropColumn(
                name: "MiddleName",
                table: "CityVetEncoders");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "CityVetEncoders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "CityVetEncoders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MiddleName",
                table: "CityVetEncoders",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
