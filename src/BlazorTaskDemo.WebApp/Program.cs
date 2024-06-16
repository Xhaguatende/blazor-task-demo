using BlazorTaskDemo.WebApp.Components;
using BlazorTaskDemo.WebApp.Features.ScheduleTasks.Services;
using BlazorTaskDemo.WebApp.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;

services.AddRazorComponents()
    .AddInteractiveServerComponents();

services.AddScoped<IScheduleTaskServices, ScheduleTaskServices>();

services.AddOptions<DbSettings>()
    .Bind(builder.Configuration.GetSection(nameof(DbSettings)));

services.AddDbContext<TaskContext>(
    (serviceProvider, options) =>
    {
        var dbSettings = serviceProvider.GetService<IOptions<DbSettings>>()!.Value;

        options.UseSqlServer(dbSettings.ConnectionString);
    });

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var sp = scope.ServiceProvider;
    try
    {
        var context = sp.GetRequiredService<TaskContext>();
        context.Database.Migrate();
    }
    catch (Exception ex)
    {
        var logger = sp.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred while migrating the database.");
    }
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

await app.RunAsync();