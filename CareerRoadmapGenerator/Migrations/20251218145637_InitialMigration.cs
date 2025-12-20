using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CareerRoadmapGenerator.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectIdea_Career_CareerId",
                table: "ProjectIdea");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectIdea_Skill_SkillId",
                table: "ProjectIdea");

            migrationBuilder.DropForeignKey(
                name: "FK_Resource_Career_CareerId",
                table: "Resource");

            migrationBuilder.DropForeignKey(
                name: "FK_Resource_Skill_SkillId",
                table: "Resource");

            migrationBuilder.DropForeignKey(
                name: "FK_Skill_Career_CareerId",
                table: "Skill");

            migrationBuilder.DropForeignKey(
                name: "FK_UserProgresses_Career_CareerId",
                table: "UserProgresses");

            migrationBuilder.DropForeignKey(
                name: "FK_UserProgresses_Skill_SkillId",
                table: "UserProgresses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Skill",
                table: "Skill");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Resource",
                table: "Resource");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProjectIdea",
                table: "ProjectIdea");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Career",
                table: "Career");

            migrationBuilder.RenameTable(
                name: "Skill",
                newName: "Skills");

            migrationBuilder.RenameTable(
                name: "Resource",
                newName: "Resources");

            migrationBuilder.RenameTable(
                name: "ProjectIdea",
                newName: "ProjectIdeas");

            migrationBuilder.RenameTable(
                name: "Career",
                newName: "Careers");

            migrationBuilder.RenameIndex(
                name: "IX_Skill_CareerId",
                table: "Skills",
                newName: "IX_Skills_CareerId");

            migrationBuilder.RenameIndex(
                name: "IX_Resource_SkillId",
                table: "Resources",
                newName: "IX_Resources_SkillId");

            migrationBuilder.RenameIndex(
                name: "IX_Resource_CareerId",
                table: "Resources",
                newName: "IX_Resources_CareerId");

            migrationBuilder.RenameIndex(
                name: "IX_ProjectIdea_SkillId",
                table: "ProjectIdeas",
                newName: "IX_ProjectIdeas_SkillId");

            migrationBuilder.RenameIndex(
                name: "IX_ProjectIdea_CareerId",
                table: "ProjectIdeas",
                newName: "IX_ProjectIdeas_CareerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Skills",
                table: "Skills",
                column: "SkillId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Resources",
                table: "Resources",
                column: "ResourceId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProjectIdeas",
                table: "ProjectIdeas",
                column: "ProjectIdeaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Careers",
                table: "Careers",
                column: "CareerId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectIdeas_Careers_CareerId",
                table: "ProjectIdeas",
                column: "CareerId",
                principalTable: "Careers",
                principalColumn: "CareerId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectIdeas_Skills_SkillId",
                table: "ProjectIdeas",
                column: "SkillId",
                principalTable: "Skills",
                principalColumn: "SkillId");

            migrationBuilder.AddForeignKey(
                name: "FK_Resources_Careers_CareerId",
                table: "Resources",
                column: "CareerId",
                principalTable: "Careers",
                principalColumn: "CareerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Resources_Skills_SkillId",
                table: "Resources",
                column: "SkillId",
                principalTable: "Skills",
                principalColumn: "SkillId");

            migrationBuilder.AddForeignKey(
                name: "FK_Skills_Careers_CareerId",
                table: "Skills",
                column: "CareerId",
                principalTable: "Careers",
                principalColumn: "CareerId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserProgresses_Careers_CareerId",
                table: "UserProgresses",
                column: "CareerId",
                principalTable: "Careers",
                principalColumn: "CareerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserProgresses_Skills_SkillId",
                table: "UserProgresses",
                column: "SkillId",
                principalTable: "Skills",
                principalColumn: "SkillId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectIdeas_Careers_CareerId",
                table: "ProjectIdeas");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectIdeas_Skills_SkillId",
                table: "ProjectIdeas");

            migrationBuilder.DropForeignKey(
                name: "FK_Resources_Careers_CareerId",
                table: "Resources");

            migrationBuilder.DropForeignKey(
                name: "FK_Resources_Skills_SkillId",
                table: "Resources");

            migrationBuilder.DropForeignKey(
                name: "FK_Skills_Careers_CareerId",
                table: "Skills");

            migrationBuilder.DropForeignKey(
                name: "FK_UserProgresses_Careers_CareerId",
                table: "UserProgresses");

            migrationBuilder.DropForeignKey(
                name: "FK_UserProgresses_Skills_SkillId",
                table: "UserProgresses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Skills",
                table: "Skills");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Resources",
                table: "Resources");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProjectIdeas",
                table: "ProjectIdeas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Careers",
                table: "Careers");

            migrationBuilder.RenameTable(
                name: "Skills",
                newName: "Skill");

            migrationBuilder.RenameTable(
                name: "Resources",
                newName: "Resource");

            migrationBuilder.RenameTable(
                name: "ProjectIdeas",
                newName: "ProjectIdea");

            migrationBuilder.RenameTable(
                name: "Careers",
                newName: "Career");

            migrationBuilder.RenameIndex(
                name: "IX_Skills_CareerId",
                table: "Skill",
                newName: "IX_Skill_CareerId");

            migrationBuilder.RenameIndex(
                name: "IX_Resources_SkillId",
                table: "Resource",
                newName: "IX_Resource_SkillId");

            migrationBuilder.RenameIndex(
                name: "IX_Resources_CareerId",
                table: "Resource",
                newName: "IX_Resource_CareerId");

            migrationBuilder.RenameIndex(
                name: "IX_ProjectIdeas_SkillId",
                table: "ProjectIdea",
                newName: "IX_ProjectIdea_SkillId");

            migrationBuilder.RenameIndex(
                name: "IX_ProjectIdeas_CareerId",
                table: "ProjectIdea",
                newName: "IX_ProjectIdea_CareerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Skill",
                table: "Skill",
                column: "SkillId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Resource",
                table: "Resource",
                column: "ResourceId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProjectIdea",
                table: "ProjectIdea",
                column: "ProjectIdeaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Career",
                table: "Career",
                column: "CareerId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectIdea_Career_CareerId",
                table: "ProjectIdea",
                column: "CareerId",
                principalTable: "Career",
                principalColumn: "CareerId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectIdea_Skill_SkillId",
                table: "ProjectIdea",
                column: "SkillId",
                principalTable: "Skill",
                principalColumn: "SkillId");

            migrationBuilder.AddForeignKey(
                name: "FK_Resource_Career_CareerId",
                table: "Resource",
                column: "CareerId",
                principalTable: "Career",
                principalColumn: "CareerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Resource_Skill_SkillId",
                table: "Resource",
                column: "SkillId",
                principalTable: "Skill",
                principalColumn: "SkillId");

            migrationBuilder.AddForeignKey(
                name: "FK_Skill_Career_CareerId",
                table: "Skill",
                column: "CareerId",
                principalTable: "Career",
                principalColumn: "CareerId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserProgresses_Career_CareerId",
                table: "UserProgresses",
                column: "CareerId",
                principalTable: "Career",
                principalColumn: "CareerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserProgresses_Skill_SkillId",
                table: "UserProgresses",
                column: "SkillId",
                principalTable: "Skill",
                principalColumn: "SkillId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
