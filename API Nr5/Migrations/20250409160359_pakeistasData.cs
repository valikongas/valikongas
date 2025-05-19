using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_Nr5.Migrations
{
    /// <inheritdoc />
    public partial class pakeistasData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DateTime",
                table: "Tasks",
                newName: "TaskDate");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TaskDate",
                table: "Tasks",
                newName: "DateTime");
        }
    }
}
