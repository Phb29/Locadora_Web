using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebLocadora.Migrations
{
    public partial class popularcategoria : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FilmeCategorias",
                columns: table => new
                {
                    FilmeCategoriaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeGenero = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilmeCategorias", x => x.FilmeCategoriaId);
                });

            migrationBuilder.CreateTable(
                name: "Filmes",
                columns: table => new
                {
                    FilmeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FilmeNome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Preco = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Disponivel = table.Column<bool>(type: "bit", nullable: false),
                    FilmeImg = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Preferido = table.Column<bool>(type: "bit", nullable: false),
                    FilmeCategoriaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Filmes", x => x.FilmeId);
                    table.ForeignKey(
                        name: "FK_Filmes_FilmeCategorias_FilmeCategoriaId",
                        column: x => x.FilmeCategoriaId,
                        principalTable: "FilmeCategorias",
                        principalColumn: "FilmeCategoriaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Filmes_FilmeCategoriaId",
                table: "Filmes",
                column: "FilmeCategoriaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Filmes");

            migrationBuilder.DropTable(
                name: "FilmeCategorias");
        }
    }
}
