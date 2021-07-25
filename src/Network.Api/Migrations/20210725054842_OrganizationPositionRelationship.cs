using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Network.Api.Migrations
{
    public partial class OrganizationPositionRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Positions_Companies_CompanyId",
                table: "Positions");

            migrationBuilder.RenameColumn(
                name: "CompanyId",
                table: "Positions",
                newName: "OrganizationId");

            migrationBuilder.RenameIndex(
                name: "IX_Positions_CompanyId",
                table: "Positions",
                newName: "IX_Positions_OrganizationId");

            migrationBuilder.AddColumn<Guid>(
                name: "OfficeId",
                table: "Positions",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Positions_OfficeId",
                table: "Positions",
                column: "OfficeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Positions_Offices_OfficeId",
                table: "Positions",
                column: "OfficeId",
                principalTable: "Offices",
                principalColumn: "OfficeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Positions_Organizations_OrganizationId",
                table: "Positions",
                column: "OrganizationId",
                principalTable: "Organizations",
                principalColumn: "OrganizationId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Positions_Offices_OfficeId",
                table: "Positions");

            migrationBuilder.DropForeignKey(
                name: "FK_Positions_Organizations_OrganizationId",
                table: "Positions");

            migrationBuilder.DropIndex(
                name: "IX_Positions_OfficeId",
                table: "Positions");

            migrationBuilder.DropColumn(
                name: "OfficeId",
                table: "Positions");

            migrationBuilder.RenameColumn(
                name: "OrganizationId",
                table: "Positions",
                newName: "CompanyId");

            migrationBuilder.RenameIndex(
                name: "IX_Positions_OrganizationId",
                table: "Positions",
                newName: "IX_Positions_CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Positions_Companies_CompanyId",
                table: "Positions",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "CompanyId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
