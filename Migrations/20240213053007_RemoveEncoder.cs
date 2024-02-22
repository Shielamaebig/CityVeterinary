using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CityVeterinary.Migrations
{
    /// <inheritdoc />
    public partial class RemoveEncoder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Encoders");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Encoders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateAdded = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EncoderName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Encoders", x => x.Id);
                });
        }
    }
}
