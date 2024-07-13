using MovieGraphQL.Data;
using MovieGraphQL.Exceptions;
using MovieGraphQL.Models;

namespace MovieGraphQL.GraphQL;

public class Mutation
{
    public async Task<Movie> AddMovie(string name, string external_Id, bool? favorite, [Service] Context dbContext)
    {
        var movie = new Movie { Name = name, External_Id = external_Id, Favorite = favorite ?? false };
        await dbContext.Movies.AddAsync(movie);
        await dbContext.SaveChangesAsync();
        return movie;
    }

    public async Task<Movie> UpdateMovie(int id, bool? favorite, [Service] Context dbContext)
    {
        var movie = await dbContext.Movies.FindAsync(id) ?? throw new MovieNotFoundException(id);
        if (favorite.HasValue)
        {
            movie.Favorite = favorite.Value;
        }

        await dbContext.SaveChangesAsync();
        return movie;
    }

    public async Task<Response> RemoveMovie(int id, [Service] Context dbContext)
    {
        try
        {
            var movie = await dbContext.Movies.FindAsync(id) ?? throw new MovieNotFoundException(id);
            dbContext.Movies.Remove(movie);
            await dbContext.SaveChangesAsync();
            Response response = new() { Success = true, Message = "Filme removido com sucesso" };
            return response;
        }
        catch (Exception e)
        {
            Response response = new() { Success = false, Message = e.Message };
            return response;
        }        
    }
}
