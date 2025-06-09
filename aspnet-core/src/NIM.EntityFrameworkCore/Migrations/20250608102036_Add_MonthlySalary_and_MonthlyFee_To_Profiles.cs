using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NIM.Migrations
{
    /// <inheritdoc />
    public partial class Add_MonthlySalary_and_MonthlyFee_To_Profiles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "MonthlySalary",
                table: "TeacherProfiles",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "MonthlyFee",
                table: "StudentProfiles",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "MonthlySalary",
                table: "PrincipalProfiles",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "MonthlySalary",
                table: "AccountantProfiles",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MonthlySalary",
                table: "TeacherProfiles");

            migrationBuilder.DropColumn(
                name: "MonthlyFee",
                table: "StudentProfiles");

            migrationBuilder.DropColumn(
                name: "MonthlySalary",
                table: "PrincipalProfiles");

            migrationBuilder.DropColumn(
                name: "MonthlySalary",
                table: "AccountantProfiles");
        }
    }
}
