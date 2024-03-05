namespace BookShelf;

using Data;
using Data.Initializer;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using Polly;
using Schema;

public static class HostingExtensions
{
    public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddDbContext<BookShelfContext>(options =>
        {
            options
                .UseNpgsql(builder.Configuration.GetConnectionString("BookShelfConnection"))
                .UseSnakeCaseNamingConvention();
        });
        
        builder.Services.AddGraphQLServer()
            .RegisterDbContext<BookShelfContext>()
            .AddQueryType<Query>()
            .AddMutationType<Mutation>()
            .AddFiltering();

        return builder.Build();
    }

    public static WebApplication ConfigurePipeline(this WebApplication app)
    {
        app.MapGraphQL();
        
        var retryPolicy = Policy.Handle<NpgsqlException>()
            .WaitAndRetry(5, retryAttempt => TimeSpan.FromSeconds(10));

        retryPolicy.ExecuteAndCapture(() => SeedInitialData.Initialize(app));
        return app;
    }
}