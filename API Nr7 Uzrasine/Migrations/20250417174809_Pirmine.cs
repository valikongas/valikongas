using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_Nr7_Uzrasine.Migrations
{
    /// <inheritdoc />
    public partial class Pirmine : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UsersUzrasine",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersUzrasine", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CategoriesUZrasine",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriesUZrasine", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CategoriesUZrasine_UsersUzrasine_UserId",
                        column: x => x.UserId,
                        principalTable: "UsersUzrasine",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MessagesUzrasine",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MessagesUzrasine", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MessagesUzrasine_CategoriesUZrasine_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "CategoriesUZrasine",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoriesUZrasine_UserId",
                table: "CategoriesUZrasine",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_MessagesUzrasine_CategoryId",
                table: "MessagesUzrasine",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MessagesUzrasine");

            migrationBuilder.DropTable(
                name: "CategoriesUZrasine");

            migrationBuilder.DropTable(
                name: "UsersUzrasine");
        }
    }
}
