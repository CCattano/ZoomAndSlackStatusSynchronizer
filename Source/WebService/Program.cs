using Synchronizer.Infrastructure.Clients.Slack;

Console.Title = "StatusSync";
WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
builder.WebHost.UseKestrel().UseIISIntegration().UseUrls("http://localhost:2362");

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ISlackClient, SlackClient>();

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

await app.RunAsync();