using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PokemonTypes",
                columns: table => new
                {
                    TypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IMG = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PokemonTypes", x => x.TypeId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IMG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ws = table.Column<int>(type: "int", nullable: false),
                    Ls = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PokemonMoves",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Power = table.Column<int>(type: "int", nullable: false),
                    Accuracy = table.Column<int>(type: "int", nullable: false),
                    PokemonTypes = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PokemonMoves", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PokemonMoves_PokemonTypes_PokemonTypes",
                        column: x => x.PokemonTypes,
                        principalTable: "PokemonTypes",
                        principalColumn: "TypeId");
                });

            migrationBuilder.CreateTable(
                name: "Pokemons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IMG = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HP = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    speed = table.Column<int>(type: "int", nullable: false),
                    attack = table.Column<int>(type: "int", nullable: false),
                    defense = table.Column<int>(type: "int", nullable: false),
                    TypeId = table.Column<int>(type: "int", nullable: true),
                    WeaknessTypeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pokemons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pokemons_PokemonTypes_TypeId",
                        column: x => x.TypeId,
                        principalTable: "PokemonTypes",
                        principalColumn: "TypeId");
                    table.ForeignKey(
                        name: "FK_Pokemons_PokemonTypes_WeaknessTypeId",
                        column: x => x.WeaknessTypeId,
                        principalTable: "PokemonTypes",
                        principalColumn: "TypeId");
                });

            migrationBuilder.CreateTable(
                name: "Battles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Users = table.Column<int>(type: "int", nullable: true),
                    User2Id = table.Column<int>(type: "int", nullable: true),
                    ActivePokemonTrainer1Id = table.Column<int>(type: "int", nullable: true),
                    ActivePokemonTrainer2Id = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Battles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Battles_Pokemons_ActivePokemonTrainer1Id",
                        column: x => x.ActivePokemonTrainer1Id,
                        principalTable: "Pokemons",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Battles_Pokemons_ActivePokemonTrainer2Id",
                        column: x => x.ActivePokemonTrainer2Id,
                        principalTable: "Pokemons",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Battles_Users_User2Id",
                        column: x => x.User2Id,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Battles_Users_Users",
                        column: x => x.Users,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

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

            migrationBuilder.CreateTable(
                name: "BattleMoves",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PokemonMoveId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    BattleId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BattleMoves", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BattleMoves_Battles_BattleId",
                        column: x => x.BattleId,
                        principalTable: "Battles",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BattleMoves_PokemonMoves_PokemonMoveId",
                        column: x => x.PokemonMoveId,
                        principalTable: "PokemonMoves",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BattleMoves_Pokemons_UserId",
                        column: x => x.UserId,
                        principalTable: "Pokemons",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_BattleMoves_BattleId",
                table: "BattleMoves",
                column: "BattleId");

            migrationBuilder.CreateIndex(
                name: "IX_BattleMoves_PokemonMoveId",
                table: "BattleMoves",
                column: "PokemonMoveId");

            migrationBuilder.CreateIndex(
                name: "IX_BattleMoves_UserId",
                table: "BattleMoves",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Battles_ActivePokemonTrainer1Id",
                table: "Battles",
                column: "ActivePokemonTrainer1Id");

            migrationBuilder.CreateIndex(
                name: "IX_Battles_ActivePokemonTrainer2Id",
                table: "Battles",
                column: "ActivePokemonTrainer2Id");

            migrationBuilder.CreateIndex(
                name: "IX_Battles_User2Id",
                table: "Battles",
                column: "User2Id");

            migrationBuilder.CreateIndex(
                name: "IX_Battles_Users",
                table: "Battles",
                column: "Users");

            migrationBuilder.CreateIndex(
                name: "IX_PokemonMoves_PokemonTypes",
                table: "PokemonMoves",
                column: "PokemonTypes");

            migrationBuilder.CreateIndex(
                name: "IX_PokemonPokemonMove_PokemonsId",
                table: "PokemonPokemonMove",
                column: "PokemonsId");

            migrationBuilder.CreateIndex(
                name: "IX_Pokemons_TypeId",
                table: "Pokemons",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Pokemons_WeaknessTypeId",
                table: "Pokemons",
                column: "WeaknessTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_PokemonUser_UsersId",
                table: "PokemonUser",
                column: "UsersId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BattleMoves");

            migrationBuilder.DropTable(
                name: "PokemonPokemonMove");

            migrationBuilder.DropTable(
                name: "PokemonUser");

            migrationBuilder.DropTable(
                name: "Battles");

            migrationBuilder.DropTable(
                name: "PokemonMoves");

            migrationBuilder.DropTable(
                name: "Pokemons");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "PokemonTypes");
        }
    }
}
