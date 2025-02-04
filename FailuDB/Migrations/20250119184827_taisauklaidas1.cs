using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FailuDB.Migrations
{
    /// <inheritdoc />
    public partial class taisauklaidas1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Failu_FailuFolders_FolderIDId",
                table: "Failu");

            migrationBuilder.RenameColumn(
                name: "FolderIDId",
                table: "Failu",
                newName: "FolderID");

            migrationBuilder.RenameIndex(
                name: "IX_Failu_FolderIDId",
                table: "Failu",
                newName: "IX_Failu_FolderID");

            migrationBuilder.AddForeignKey(
                name: "FK_Failu_FailuFolders_FolderID",
                table: "Failu",
                column: "FolderID",
                principalTable: "FailuFolders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Failu_FailuFolders_FolderID",
                table: "Failu");

            migrationBuilder.RenameColumn(
                name: "FolderID",
                table: "Failu",
                newName: "FolderIDId");

            migrationBuilder.RenameIndex(
                name: "IX_Failu_FolderID",
                table: "Failu",
                newName: "IX_Failu_FolderIDId");

            migrationBuilder.AddForeignKey(
                name: "FK_Failu_FailuFolders_FolderIDId",
                table: "Failu",
                column: "FolderIDId",
                principalTable: "FailuFolders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
