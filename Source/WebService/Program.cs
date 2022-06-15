using Synchronizer.Infrastructure.Clients.Slack;
using Synchronizer.Web.Service.Middleware;

Console.Title = "StatusSync";
WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
Console.WriteLine("Use Localhost?\n\n[Y]es / [N]o\n");
bool runLocalhost = Console.ReadKey().Key == ConsoleKey.Y;
Console.Clear();
builder.WebHost
    .UseKestrel()
    .UseIISIntegration()
    .UseUrls($"http://{(runLocalhost ? "localhost" : "192.168.1.22")}:2362");

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ISlackClient, SlackClient>();

WebApplication app = builder.Build();

app.UseRequestResponseMiddleware();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

await app.RunAsync();