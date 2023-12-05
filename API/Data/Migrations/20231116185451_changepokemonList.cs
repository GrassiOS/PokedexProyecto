using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class changepokemonList : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PokemonPokemonMove");

            migrationBuilder.AddColumn<int>(
                name: "PokemonId",
                table: "PokemonMoves",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PokemonMoves_PokemonId",
                table: "PokemonMoves",
                column: "PokemonId");

            migrationBuilder.AddForeignKey(
                name: "FK_PokemonMoves_Pokemons_PokemonId",
                table: "PokemonMoves",
                column: "PokemonId",
                principalTable: "Pokemons",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PokemonMoves_Pokemons_PokemonId",
                table: "PokemonMoves");

            migrationBuilder.DropIndex(
                name: "IX_PokemonMoves_PokemonId",
                table: "PokemonMoves");

            migrationBuilder.DropColumn(
                name: "PokemonId",
                table: "PokemonMoves");

            migrationBuilder.CreateTable(
                name: "PokemonPokemonMove",
                columns: table => new
                {
                    PokemonMovesId = table.Column<int>(type: "int", nullable: false),
                    PokemonsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PokemonPokemonMove", x => new { x.PokemonMovesId, x.PokemonsId });
                    table.ForeignKey(
                        name: "FK_PokemonPokemonMove_PokemonMoves_PokemonMovesId",
                        column: x => x.PokemonMovesId,
                        principalTable: "PokemonMoves",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PokemonPokemonMove_Pokemons_PokemonsId",
                        column: x => x.PokemonsId,
                        principalTable: "Pokemons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PokemonPokemonMove_PokemonsId",
                table: "PokemonPokemonMove",
                column: "PokemonsId");
        }
    }
}
