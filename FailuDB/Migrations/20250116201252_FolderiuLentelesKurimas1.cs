using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FailuDB.Migrations
{
    /// <inheritdoc />
    public partial class FolderiuLentelesKurimas1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Failu_Folder_FolderIDId",
                table: "Failu");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Folder",
                table: "Folder");

            migrationBuilder.RenameTable(
                name: "Folder",
                newName: "FailuFolders");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FailuFolders",
                table: "FailuFolders",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Failu_FailuFolders_FolderIDId",
                table: "Failu",
                column: "FolderIDId",
                principalTable: "FailuFolders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Failu_FailuFolders_FolderIDId",
                table: "Failu");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FailuFolders",
                table: "FailuFolders");

            migrationBuilder.RenameTable(
                name: "FailuFolders",
                newName: "Folder");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Folder",
                table: "Folder",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Failu_Folder_FolderIDId",
                table: "Failu",
                column: "FolderIDId",
                principalTable: "Folder",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
