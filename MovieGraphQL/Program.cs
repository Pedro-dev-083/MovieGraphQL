using HotChocolate.AspNetCore.Playground;
using HotChocolate.AspNetCore;
using Microsoft.EntityFrameworkCore;
using MovieGraphQL.Data;
using MovieGraphQL.GraphQL;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.WebHost.ConfigureKestrel(serverOptions =>
{
    serverOptions.ListenAnyIP(8080);
});
builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>()
    .AddMutationType<Mutation>();

builder.Services.AddDbContext<Context>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));


var app = builder.Build();

app.UseRouting();

app.UsePlayground(new PlaygroundOptions
{
    QueryPath = "/graphql",
    SubscriptionPath = "/graphql",
    Path = "/playground",    
});


// Apply migrations at startup
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<Context>();
    await dbContext.Database.MigrateAsync();
}


app.UseGraphQLPlayground();
app.MapGet("/", () => Results.Redirect("/graphql"));

app.MapGraphQL();

await app.RunAsync();
