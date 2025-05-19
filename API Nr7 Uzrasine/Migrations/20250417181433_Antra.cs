using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_Nr7_Uzrasine.Migrations
{
    /// <inheritdoc />
    public partial class Antra : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "UsersUzrasine");

            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordHash",
                table: "UsersUzrasine",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordSalt",
                table: "UsersUzrasine",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "UsersUzrasine");

            migrationBuilder.DropColumn(
                name: "PasswordSalt",
                table: "UsersUzrasine");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "UsersUzrasine",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
