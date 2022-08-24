using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebLocadora.Migrations
{
    public partial class AluguelCompraItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Filmes_AlugarFilmeItems_AlugarFilmeItemId",
                table: "Filmes");

            migrationBuilder.DropIndex(
                name: "IX_Filmes_AlugarFilmeItemId",
                table: "Filmes");

            migrationBuilder.DropColumn(
                name: "AlugarFilmeItemId",
                table: "Filmes");

            migrationBuilder.AlterColumn<string>(
                name: "AlugarFilmeId",
                table: "AlugarFilmeItems",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FilmeId",
                table: "AlugarFilmeItems",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AlugarFilmeItems_FilmeId",
                table: "AlugarFilmeItems",
                column: "FilmeId");

            migrationBuilder.AddForeignKey(
                name: "FK_AlugarFilmeItems_Filmes_FilmeId",
                table: "AlugarFilmeItems",
                column: "FilmeId",
                principalTable: "Filmes",
                principalColumn: "FilmeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AlugarFilmeItems_Filmes_FilmeId",
                table: "AlugarFilmeItems");

            migrationBuilder.DropIndex(
                name: "IX_AlugarFilmeItems_FilmeId",
                table: "AlugarFilmeItems");

            migrationBuilder.DropColumn(
                name: "FilmeId",
                table: "AlugarFilmeItems");

            migrationBuilder.AddColumn<int>(
                name: "AlugarFilmeItemId",
                table: "Filmes",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AlugarFilmeId",
                table: "AlugarFilmeItems",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

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
    }
}
