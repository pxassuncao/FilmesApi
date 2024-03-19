using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FilmesApi.Migrations
{
    public partial class Cinemaefilme : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sessaos_Cinemas_CinemaId",
                table: "Sessaos");

            migrationBuilder.DropForeignKey(
                name: "FK_Sessaos_Filmes_FilmeId",
                table: "Sessaos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sessaos",
                table: "Sessaos");

            migrationBuilder.DropIndex(
                name: "IX_Sessaos_FilmeId",
                table: "Sessaos");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Sessaos");

            migrationBuilder.AlterColumn<int>(
                name: "FilmeId",
                table: "Sessaos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CinemaId",
                table: "Sessaos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sessaos",
                table: "Sessaos",
                columns: new[] { "FilmeId", "CinemaId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Sessaos_Cinemas_CinemaId",
                table: "Sessaos",
                column: "CinemaId",
                principalTable: "Cinemas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sessaos_Filmes_FilmeId",
                table: "Sessaos",
                column: "FilmeId",
                principalTable: "Filmes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sessaos_Cinemas_CinemaId",
                table: "Sessaos");

            migrationBuilder.DropForeignKey(
                name: "FK_Sessaos_Filmes_FilmeId",
                table: "Sessaos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sessaos",
                table: "Sessaos");

            migrationBuilder.AlterColumn<int>(
                name: "CinemaId",
                table: "Sessaos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "FilmeId",
                table: "Sessaos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Sessaos",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sessaos",
                table: "Sessaos",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Sessaos_FilmeId",
                table: "Sessaos",
                column: "FilmeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sessaos_Cinemas_CinemaId",
                table: "Sessaos",
                column: "CinemaId",
                principalTable: "Cinemas",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Sessaos_Filmes_FilmeId",
                table: "Sessaos",
                column: "FilmeId",
                principalTable: "Filmes",
                principalColumn: "Id");
        }
    }
}
