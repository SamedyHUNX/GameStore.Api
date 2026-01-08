using GameStore.Api.Dtos;

const string EndpointName = "GetGame";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

var app = builder.Build();

List<GameDto> games = [
    new (1, "Street Fighter 2", "Fighting", 19.99M, new DateOnly(1992, 7, 15)),
    new (2, "Placeholder Game A", "Action", 29.99M, new DateOnly(2000, 1, 1)),
    new (3, "Placeholder Game B", "Adventure", 39.99M, new DateOnly(2001, 2, 2)),
    new (4, "Placeholder Game C", "RPG", 49.99M, new DateOnly(2002, 3, 3)),
    new (5, "Placeholder Game D", "Shooter", 59.99M, new DateOnly(2003, 4, 4)),
    new (6, "Placeholder Game E", "Puzzle", 9.99M, new DateOnly(2004, 5, 5)),
    new (7, "Placeholder Game F", "Sports", 19.99M, new DateOnly(2005, 6, 6)),
    new (8, "Placeholder Game G", "Racing", 29.99M, new DateOnly(2006, 7, 7)),
    new (9, "Placeholder Game H", "Strategy", 39.99M, new DateOnly(2007, 8, 8)),
    new (10, "Placeholder Game I", "Simulation", 49.99M, new DateOnly(2008, 9, 9))
];

app.MapGet("/games", () => games);

app.MapGet("/games/{id}", (int id) => games.Find(game => game.Id == id)).WithName(EndpointName);
app.MapPost("/games", (CreateGameDto newGame) =>
{
    GameDto game = new(
        games.Count + 1,
        newGame.Name,
        newGame.Genre,
        newGame.Price,
        newGame.ReleaseDate
    );

    games.Add(game);

    return Results.CreatedAtRoute(EndpointName, new {id = game.Id}, game);
});

app.Run();
