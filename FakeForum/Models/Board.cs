using System.ComponentModel.DataAnnotations.Schema;

public class Board
{
    [Column("id")]
    public int Id { get; set; }

    [Column("name")]
    public string Name { get; set; }

    [Column("description")]
    public string Description { get; set; }

    [Column("createdat")]
    public DateTime CreatedAt { get; set; }
}