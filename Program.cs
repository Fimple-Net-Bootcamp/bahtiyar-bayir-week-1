using fimple_bootcamp_week_1_homework.DBOperations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var _host = Host.CreateDefaultBuilder().ConfigureServices(
    services =>
    {
        services.AddDbContext<LibraryDbContext>(options => options.UseInMemoryDatabase(databaseName: "LibraryManagerDB"));
        services.AddScoped<ILibraryDbContext>(provider => provider.GetService<LibraryDbContext>());
    }).Build();

using (var scope = _host.Services.CreateAsyncScope())
{
    var services = scope.ServiceProvider;
    DataGenerator.Initialize(services);
};

var _libraryDbContext = _host.Services.GetRequiredService<ILibraryDbContext>();

Console.WriteLine(_libraryDbContext.Books.FirstOrDefault(book => book.Id == 1).Title);