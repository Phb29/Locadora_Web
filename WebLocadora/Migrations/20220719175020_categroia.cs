using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebLocadora.Migrations
{
    public partial class categroia : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO FilmeCategorias(NomeGenero,Descricao)" +
            "Values('comédia','filmes De comédia')");
            migrationBuilder.Sql("INSERT INTO FilmeCategorias(NomeGenero,Descricao)" +
           "Values('Ação','filmes De Ação')");
            migrationBuilder.Sql("INSERT INTO FilmeCategorias(NomeGenero,Descricao)" +
           "Values('Terror','filmes De Terror')");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Delete From FilmeCategorias ");


        }
    }
}
