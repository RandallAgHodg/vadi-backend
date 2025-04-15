using Application;
using DataAccess;
using DataAccess.Database;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;

var config = builder.Configuration;

// Add services to the container.

services
    .AddEndpointsApiExplorer()
    .AddSwaggerGen()
    .AddDataAccess(config)
    .AddApplication()
    .AddControllers();

var app = builder.Build();

var databaseInitializer = app.Services.GetRequiredService<DatabaseInitializer>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
