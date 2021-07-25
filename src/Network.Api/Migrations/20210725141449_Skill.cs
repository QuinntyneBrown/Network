using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Network.Api.Migrations
{
    public partial class Skill : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    SkillId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.SkillId);
                });

            migrationBuilder.CreateTable(
                name: "ProfileSkill",
                columns: table => new
                {
                    ProfilesProfileId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SkillsSkillId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfileSkill", x => new { x.ProfilesProfileId, x.SkillsSkillId });
                    table.ForeignKey(
                        name: "FK_ProfileSkill_Profiles_ProfilesProfileId",
                        column: x => x.ProfilesProfileId,
                        principalTable: "Profiles",
                        principalColumn: "ProfileId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProfileSkill_Skills_SkillsSkillId",
                        column: x => x.SkillsSkillId,
                        principalTable: "Skills",
                        principalColumn: "SkillId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProfileSkill_SkillsSkillId",
                table: "ProfileSkill",
                column: "SkillsSkillId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProfileSkill");

            migrationBuilder.DropTable(
                name: "Skills");
        }
    }
}
