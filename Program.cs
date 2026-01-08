using GameStore.Api.Endpoints;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

var app = builder.Build();

app.MapGamesEndpoints();

app.Run();
