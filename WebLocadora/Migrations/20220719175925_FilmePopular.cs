using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebLocadora.Migrations
{
    public partial class FilmePopular : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Filmes(FilmeCategoriaId,FilmeNome,Preco,Disponivel,FilmeImg,Preferido)" +
                "Values(1,'HarryPotter',10.00,1,'http://www.macoratti.net/Imagens/lanches/mistoquente4.jpg',1)");
            migrationBuilder.Sql("INSERT INTO Filmes(FilmeCategoriaId,FilmeNome,Preco,Disponivel,FilmeImg,Preferido)" +
                "Values(2,'Velozes e furiosos',12.00,1,'http://www.macoratti.net/Imagens/lanches/mistoquente4.jpg',0 )");
            migrationBuilder.Sql("INSERT INTO Filmes(FilmeCategoriaId,FilmeNome,Preco,Disponivel,FilmeImg,Preferido)" +
                            "Values(3,'Sexta-feira 13',10.00,1,'http://www.macoratti.net/Imagens/lanches/mistoquente4.jpg',1)");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Delete From Filmes");
        }
    }
}
