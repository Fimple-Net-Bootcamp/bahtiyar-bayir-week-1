using fimple_bootcamp_week_1_homework.DBOperations;
using fimple_bootcamp_week_1_homework.Manager;
using fimple_bootcamp_week_1_homework.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Reflection;

Console.Title = "Week 1 - Fimple library app";
Console.SetWindowSize(144, 48);
Console.SetWindowPosition(0, 0);

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

var _manager = _host.Services.GetRequiredService<IManager>();

_manager.Start();
