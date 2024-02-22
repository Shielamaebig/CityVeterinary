using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CityVeterinary.Migrations
{
    /// <inheritdoc />
    public partial class CityVetRemoveGuid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GuidNumber",
                table: "RecentActivities");

            migrationBuilder.DropColumn(
                name: "PetVaxGuid",
                table: "PetVaccines");

            migrationBuilder.DropColumn(
                name: "PetTypeGuid",
                table: "PetTypes");

            migrationBuilder.DropColumn(
                name: "PetOwnerGuid",
                table: "PetOwners");

            migrationBuilder.DropColumn(
                name: "PetInfoGuid",
                table: "PetInformations");

            migrationBuilder.DropColumn(
                name: "BreedTypeGuid",
                table: "BreedTypes");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Encoders",
                newName: "Id");

            migrationBuilder.AddColumn<string>(
                name: "BreedType",
                table: "PetVaccines",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "PetVaccines",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PetName",
                table: "PetVaccines",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PetType",
                table: "PetVaccines",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Powner",
                table: "PetVaccines",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VaccinatorName",
                table: "PetVaccines",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VaccineName",
                table: "PetVaccines",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VeterinarianName",
                table: "PetVaccines",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "PetOwners",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BreedType",
                table: "PetVaccines");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "PetVaccines");

            migrationBuilder.DropColumn(
                name: "PetName",
                table: "PetVaccines");

            migrationBuilder.DropColumn(
                name: "PetType",
                table: "PetVaccines");

            migrationBuilder.DropColumn(
                name: "Powner",
                table: "PetVaccines");

            migrationBuilder.DropColumn(
                name: "VaccinatorName",
                table: "PetVaccines");

            migrationBuilder.DropColumn(
                name: "VaccineName",
                table: "PetVaccines");

            migrationBuilder.DropColumn(
                name: "VeterinarianName",
                table: "PetVaccines");

            migrationBuilder.DropColumn(
                name: "FullName",
                table: "PetOwners");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Encoders",
                newName: "id");

            migrationBuilder.AddColumn<string>(
                name: "GuidNumber",
                table: "RecentActivities",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "PetVaxGuid",
                table: "PetVaccines",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "PetTypeGuid",
                table: "PetTypes",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "PetOwnerGuid",
                table: "PetOwners",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "PetInfoGuid",
                table: "PetInformations",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "BreedTypeGuid",
                table: "BreedTypes",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }
    }
}
