using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebLocadora.Migrations
{
    public partial class AlugarFilmeItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AlugarFilmeItemId",
                table: "Filmes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AlugarFilmeItems",
                columns: table => new
                {
                    AlugarFilmeItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantidade = table.Column<int>(type: "int", nullable: false),
                    AlugarFilmeId = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlugarFilmeItems", x => x.AlugarFilmeItemId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Filmes_AlugarFilmeItemId",
                table: "Filmes",
                column: "AlugarFilmeItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Filmes_AlugarFilmeItems_AlugarFilmeItemId",
                table: "Filmes",
                column: "AlugarFilmeItemId",
                principalTable: "AlugarFilmeItems",
                principalColumn: "AlugarFilmeItemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Filmes_AlugarFilmeItems_AlugarFilmeItemId",
                table: "Filmes");

            migrationBuilder.DropTable(
                name: "AlugarFilmeItems");

            migrationBuilder.DropIndex(
                name: "IX_Filmes_AlugarFilmeItemId",
                table: "Filmes");

            migrationBuilder.DropColumn(
                name: "AlugarFilmeItemId",
                table: "Filmes");
        }
    }
}
