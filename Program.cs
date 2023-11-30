using fimple_bootcamp_week_1_homework.DBOperations;
using fimple_bootcamp_week_1_homework.Manager;
using fimple_bootcamp_week_1_homework.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Reflection;

var _host = Host.CreateDefaultBuilder().ConfigureServices(
    services =>
    {
        services.AddDbContext<LibraryDbContext>(options => options.UseInMemoryDatabase(databaseName: "LibraryManagerDB"));
        services.AddScoped<ILibraryDbContext>(provider => provider.GetService<LibraryDbContext>());
        services.AddScoped<ICustomisedMessagePrinter, CustomisedMessagePrinter>();
        services.AddScoped<IManager, Manager>();
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
    }).Build();

using (var scope = _host.Services.CreateAsyncScope())
{
    var services = scope.ServiceProvider;
    DataGenerator.Initialize(services);
};

var _libraryDbContext = _host.Services.GetRequiredService<ILibraryDbContext>();
var _logger = _host.Services.GetRequiredService<ICustomisedMessagePrinter>();
var _manager = _host.Services.GetRequiredService<IManager>();

_manager.Start();
