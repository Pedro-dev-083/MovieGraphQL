namespace MovieGraphQL.Models;

public class Movie
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string External_Id { get; set; }
    public bool Favorite { get; set; }
}
