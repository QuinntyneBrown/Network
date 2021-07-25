using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Network.Api.Migrations
{
    public partial class OrganizationRelationships : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "LogoDigitalAssetId",
                table: "Organizations",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CompanyTeams",
                columns: table => new
                {
                    CompanyTeamId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyTeams", x => x.CompanyTeamId);
                });

            migrationBuilder.CreateTable(
                name: "OrganizationTeams",
                columns: table => new
                {
                    OrganizationTeamId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganizationTeams", x => x.OrganizationTeamId);
                });

            migrationBuilder.CreateTable(
                name: "OrganizationTechnologies",
                columns: table => new
                {
                    OrganizationTechnologyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganizationTechnologies", x => x.OrganizationTechnologyId);
                });

            migrationBuilder.CreateTable(
                name: "ProfileTechnologies",
                columns: table => new
                {
                    ProfileTechnologyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfileTechnologies", x => x.ProfileTechnologyId);
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    TeamId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.TeamId);
                });

            migrationBuilder.CreateTable(
                name: "TeamTechnologies",
                columns: table => new
                {
                    TeamTechnologyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamTechnologies", x => x.TeamTechnologyId);
                });

            migrationBuilder.CreateTable(
                name: "Technologies",
                columns: table => new
                {
                    TechnologyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Technologies", x => x.TechnologyId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompanyTeams");

            migrationBuilder.DropTable(
                name: "OrganizationTeams");

            migrationBuilder.DropTable(
                name: "OrganizationTechnologies");

            migrationBuilder.DropTable(
                name: "ProfileTechnologies");

            migrationBuilder.DropTable(
                name: "Teams");

            migrationBuilder.DropTable(
                name: "TeamTechnologies");

            migrationBuilder.DropTable(
                name: "Technologies");

            migrationBuilder.DropColumn(
                name: "LogoDigitalAssetId",
                table: "Organizations");
        }
    }
}
