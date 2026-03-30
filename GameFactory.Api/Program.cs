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

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<GameFactoryContext>();
    await DatabaseSeeder.SeedAsync(context);
}

app.MapControllers();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Run();