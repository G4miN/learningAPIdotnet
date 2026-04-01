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
builder.Services.AddScoped<IGameRepository, GameRepository>();
builder.Services.AddScoped<IGameService, GameService>();
builder.Services.AddControllers();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbcontext = scope.ServiceProvider.GetRequiredService<GameFactoryContext>();
    if (dbcontext.Database.GetPendingMigrations().Any())
    {
        dbcontext.Database.Migrate();
    }
}

if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    using var scope = app.Services.CreateScope();
    var context = scope.ServiceProvider.GetRequiredService<GameFactoryContext>();
    context.Database.Migrate();
    await DatabaseSeeder.SeedAsync(context);
}

app.MapControllers();
app.UseSwagger();

if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwaggerUI();
}

app.Run();