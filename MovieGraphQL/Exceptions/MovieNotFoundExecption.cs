namespace MovieGraphQL.Exceptions;

public class MovieNotFoundException(int movieId) : Exception($"Movie with ID {movieId} not found.")
{
}
