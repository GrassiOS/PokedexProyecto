using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain;

public class BattleMove
{
    [Key]
    public int Id { get; set; }

    [ForeignKey("PokemonMoveId")]
    public PokemonMove? MoveUsed { get; set; }
    [ForeignKey("UserId")]
    public Pokemon? User { get; set; }

    [ForeignKey("BattleId")] // Specifies the foreign key
    public Battle? Battle { get; set; }
}
