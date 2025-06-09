using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NIM.Migrations
{
    /// <inheritdoc />
    public partial class Add_Class_Section_To_StudentProfile : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClassId",
                table: "StudentProfiles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SectionId",
                table: "StudentProfiles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_StudentProfiles_ClassId",
                table: "StudentProfiles",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentProfiles_SectionId",
                table: "StudentProfiles",
                column: "SectionId");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentProfiles_Classes_ClassId",
                table: "StudentProfiles",
                column: "ClassId",
                principalTable: "Classes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentProfiles_Sections_SectionId",
                table: "StudentProfiles",
                column: "SectionId",
                principalTable: "Sections",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentProfiles_Classes_ClassId",
                table: "StudentProfiles");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentProfiles_Sections_SectionId",
                table: "StudentProfiles");

            migrationBuilder.DropIndex(
                name: "IX_StudentProfiles_ClassId",
                table: "StudentProfiles");

            migrationBuilder.DropIndex(
                name: "IX_StudentProfiles_SectionId",
                table: "StudentProfiles");

            migrationBuilder.DropColumn(
                name: "ClassId",
                table: "StudentProfiles");

            migrationBuilder.DropColumn(
                name: "SectionId",
                table: "StudentProfiles");
        }
    }
}
