using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CityVeterinary.Migrations
{
    /// <inheritdoc />
    public partial class CityVetPetInfoPetOwnerNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PetInformations_PetOwners_PetOwnerId",
                table: "PetInformations");

            migrationBuilder.AlterColumn<int>(
                name: "PetOwnerId",
                table: "PetInformations",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_PetInformations_PetOwners_PetOwnerId",
                table: "PetInformations",
                column: "PetOwnerId",
                principalTable: "PetOwners",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PetInformations_PetOwners_PetOwnerId",
                table: "PetInformations");

            migrationBuilder.AlterColumn<int>(
                name: "PetOwnerId",
                table: "PetInformations",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PetInformations_PetOwners_PetOwnerId",
                table: "PetInformations",
                column: "PetOwnerId",
                principalTable: "PetOwners",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
