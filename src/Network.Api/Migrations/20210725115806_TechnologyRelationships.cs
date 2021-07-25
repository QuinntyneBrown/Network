using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Network.Api.Migrations
{
    public partial class TechnologyRelationships : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ProfileTechnologies",
                table: "ProfileTechnologies");

            migrationBuilder.AddColumn<Guid>(
                name: "TechnologyId",
                table: "ProfileTechnologies",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ProfileId",
                table: "ProfileTechnologies",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ProfileId1",
                table: "ProfileTechnologies",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProfileTechnologies",
                table: "ProfileTechnologies",
                columns: new[] { "TechnologyId", "ProfileId" });

            migrationBuilder.CreateIndex(
                name: "IX_ProfileTechnologies_ProfileId",
                table: "ProfileTechnologies",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfileTechnologies_ProfileId1",
                table: "ProfileTechnologies",
                column: "ProfileId1");

            migrationBuilder.AddForeignKey(
                name: "FK_ProfileTechnologies_Profiles_ProfileId",
                table: "ProfileTechnologies",
                column: "ProfileId",
                principalTable: "Profiles",
                principalColumn: "ProfileId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProfileTechnologies_Profiles_ProfileId1",
                table: "ProfileTechnologies",
                column: "ProfileId1",
                principalTable: "Profiles",
                principalColumn: "ProfileId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProfileTechnologies_Technologies_TechnologyId",
                table: "ProfileTechnologies",
                column: "TechnologyId",
                principalTable: "Technologies",
                principalColumn: "TechnologyId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProfileTechnologies_Profiles_ProfileId",
                table: "ProfileTechnologies");

            migrationBuilder.DropForeignKey(
                name: "FK_ProfileTechnologies_Profiles_ProfileId1",
                table: "ProfileTechnologies");

            migrationBuilder.DropForeignKey(
                name: "FK_ProfileTechnologies_Technologies_TechnologyId",
                table: "ProfileTechnologies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProfileTechnologies",
                table: "ProfileTechnologies");

            migrationBuilder.DropIndex(
                name: "IX_ProfileTechnologies_ProfileId",
                table: "ProfileTechnologies");

            migrationBuilder.DropIndex(
                name: "IX_ProfileTechnologies_ProfileId1",
                table: "ProfileTechnologies");

            migrationBuilder.DropColumn(
                name: "TechnologyId",
                table: "ProfileTechnologies");

            migrationBuilder.DropColumn(
                name: "ProfileId",
                table: "ProfileTechnologies");

            migrationBuilder.DropColumn(
                name: "ProfileId1",
                table: "ProfileTechnologies");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProfileTechnologies",
                table: "ProfileTechnologies",
                column: "ProfileTechnologyId");
        }
    }
}
