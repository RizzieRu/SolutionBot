using SolutionBot.Services;
using SolutionBot.Services.Inferfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true, reloadOnChange: true)
    .AddEnvironmentVariables();

builder.Services.AddControllersWithViews();

// Services
builder.Services.AddScoped<IHookHandlerService, HookHandlerService>();
builder.Services.AddScoped<ITelegramService, TelegramService>();
builder.Services.AddScoped<ISolutionCommandsService, SolutionCommandsService>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Api}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();