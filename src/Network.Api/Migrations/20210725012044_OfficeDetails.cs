using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Network.Api.Migrations
{
    public partial class OfficeDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address_City",
                table: "Offices",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address_PostalCode",
                table: "Offices",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address_Province",
                table: "Offices",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address_Street",
                table: "Offices",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "OrganizationId",
                table: "Offices",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Offices_OrganizationId",
                table: "Offices",
                column: "OrganizationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Offices_Organizations_OrganizationId",
                table: "Offices",
                column: "OrganizationId",
                principalTable: "Organizations",
                principalColumn: "OrganizationId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Offices_Organizations_OrganizationId",
                table: "Offices");

            migrationBuilder.DropIndex(
                name: "IX_Offices_OrganizationId",
                table: "Offices");

            migrationBuilder.DropColumn(
                name: "Address_City",
                table: "Offices");

            migrationBuilder.DropColumn(
                name: "Address_PostalCode",
                table: "Offices");

            migrationBuilder.DropColumn(
                name: "Address_Province",
                table: "Offices");

            migrationBuilder.DropColumn(
                name: "Address_Street",
                table: "Offices");

            migrationBuilder.DropColumn(
                name: "OrganizationId",
                table: "Offices");
        }
    }
}
