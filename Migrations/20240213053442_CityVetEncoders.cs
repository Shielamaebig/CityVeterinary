using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CityVeterinary.Migrations
{
    /// <inheritdoc />
    public partial class CityVetEncoders : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CityVetEncoders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateAdded = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EncoderName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CityVetEncoders", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CityVetEncoders");
        }
    }
}
