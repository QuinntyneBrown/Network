using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Network.Api.Migrations
{
    public partial class ProfileTechnologyProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Technologies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LedBy",
                table: "Technologies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "LogoDigitalAssetId",
                table: "Technologies",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Technologies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "YearsExperience",
                table: "ProfileTechnologies",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Technologies");

            migrationBuilder.DropColumn(
                name: "LedBy",
                table: "Technologies");

            migrationBuilder.DropColumn(
                name: "LogoDigitalAssetId",
                table: "Technologies");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Technologies");

            migrationBuilder.DropColumn(
                name: "YearsExperience",
                table: "ProfileTechnologies");
        }
    }
}
