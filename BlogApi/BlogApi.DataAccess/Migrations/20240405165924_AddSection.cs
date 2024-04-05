using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogApi.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddSection : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SectionId",
                table: "Posts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Sections",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sections", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Posts_SectionId",
                table: "Posts",
                column: "SectionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Sections_SectionId",
                table: "Posts",
                column: "SectionId",
                principalTable: "Sections",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Sections_SectionId",
                table: "Posts");

            migrationBuilder.DropTable(
                name: "Sections");

            migrationBuilder.DropIndex(
                name: "IX_Posts_SectionId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "SectionId",
                table: "Posts");
        }
    }
}
