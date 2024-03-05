using BookShelf;

try
{
    var builder = WebApplication.CreateBuilder(args);

    var app = builder
        .ConfigureServices()
        .ConfigurePipeline();

    app.Run();
}
catch (Exception ex)
{
    Console.WriteLine("Unhandled Exception", ex);
}
finally
{
    Console.WriteLine("Shutting down...");
}