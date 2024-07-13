using Microsoft.EntityFrameworkCore;
using MovieGraphQL.Models;

namespace MovieGraphQL.Data;

public class Context(DbContextOptions<Context> options) : DbContext(options)
{
    public DbSet<Movie> Movies { get; set; }
}
