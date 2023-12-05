using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class changeUsersPokemonList : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PokemonUser");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Pokemons",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pokemons_UserId",
                table: "Pokemons",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pokemons_Users_UserId",
                table: "Pokemons",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pokemons_Users_UserId",
                table: "Pokemons");

            migrationBuilder.DropIndex(
                name: "IX_Pokemons_UserId",
                table: "Pokemons");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Pokemons");

            migrationBuilder.CreateTable(
                name: "PokemonUser",
                columns: table => new
                {
                    PokemonCollectionId = table.Column<int>(type: "int", nullable: false),
                    UsersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PokemonUser", x => new { x.PokemonCollectionId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_PokemonUser_Pokemons_PokemonCollectionId",
                        column: x => x.PokemonCollectionId,
                        principalTable: "Pokemons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PokemonUser_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PokemonUser_UsersId",
                table: "PokemonUser",
                column: "UsersId");
        }
    }
}
