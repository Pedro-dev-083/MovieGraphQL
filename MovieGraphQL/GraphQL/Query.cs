using MovieGraphQL.Data;
using MovieGraphQL.Models;

namespace MovieGraphQL.GraphQL;

public class Query
{
    public IQueryable<Movie> GetMovies([Service] Context dbContext)
    {
        return dbContext.Movies;
    }

    public Movie? GetMovie(int id, [Service] Context dbContext)
    {
        return dbContext.Movies.FirstOrDefault(m => m.Id == id);
    }
}
