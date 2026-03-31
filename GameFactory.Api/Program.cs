using GameFactory.Api.Data;
using GameFactory.Api.Repository;
using GameFactory.Api.Services;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddValidation();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<GameFactoryContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IGameRepository, GameRespository>();
builder.Services.AddScoped<IGameService, GameService>();
builder.Services.AddControllers();
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    using var scope = app.Services.CreateScope();
    var context = scope.ServiceProvider.GetRequiredService<GameFactoryContext>();
    await DatabaseSeeder.SeedAsync(context);
}

app.MapControllers();

app.UseSwagger();

if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwaggerUI();
}

app.Run();