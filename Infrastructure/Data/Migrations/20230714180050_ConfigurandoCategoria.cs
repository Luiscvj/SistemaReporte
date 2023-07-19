using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class ConfigurandoCategoria : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hardware_Cateoria_CategoriaId",
                table: "Hardware");

            migrationBuilder.DropForeignKey(
                name: "FK_Software_Cateoria_CategoriaId",
                table: "Software");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cateoria",
                table: "Cateoria");

            migrationBuilder.RenameTable(
                name: "Cateoria",
                newName: "Categoria");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categoria",
                table: "Categoria",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Hardware_Categoria_CategoriaId",
                table: "Hardware",
                column: "CategoriaId",
                principalTable: "Categoria",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Software_Categoria_CategoriaId",
                table: "Software",
                column: "CategoriaId",
                principalTable: "Categoria",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hardware_Categoria_CategoriaId",
                table: "Hardware");

            migrationBuilder.DropForeignKey(
                name: "FK_Software_Categoria_CategoriaId",
                table: "Software");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categoria",
                table: "Categoria");

            migrationBuilder.RenameTable(
                name: "Categoria",
                newName: "Cateoria");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cateoria",
                table: "Cateoria",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Hardware_Cateoria_CategoriaId",
                table: "Hardware",
                column: "CategoriaId",
                principalTable: "Cateoria",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Software_Cateoria_CategoriaId",
                table: "Software",
                column: "CategoriaId",
                principalTable: "Cateoria",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
