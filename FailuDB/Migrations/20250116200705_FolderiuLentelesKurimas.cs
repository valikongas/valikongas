using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FailuDB.Migrations
{
    /// <inheritdoc />
    public partial class FolderiuLentelesKurimas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FolderIDId",
                table: "Failu",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Folder",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Folder", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Failu_FolderIDId",
                table: "Failu",
                column: "FolderIDId");

            migrationBuilder.AddForeignKey(
                name: "FK_Failu_Folder_FolderIDId",
                table: "Failu",
                column: "FolderIDId",
                principalTable: "Folder",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Failu_Folder_FolderIDId",
                table: "Failu");

            migrationBuilder.DropTable(
                name: "Folder");

            migrationBuilder.DropIndex(
                name: "IX_Failu_FolderIDId",
                table: "Failu");

            migrationBuilder.DropColumn(
                name: "FolderIDId",
                table: "Failu");
        }
    }
}
