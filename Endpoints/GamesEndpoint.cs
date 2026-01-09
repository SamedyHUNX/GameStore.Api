using GameStore.Api.Data;
using GameStore.Api.Dtos;
using GameStore.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Api.Endpoints;

public static class GamesEndpoint
{
    const string EndpointName = "GetGame";
    private static readonly List<GameSummaryDto> games = [
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

    public static void MapGamesEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("/games");

        group.MapGet("/", async (GameStoreContext dbContext) => await dbContext.Games.Include(game => game.Genre) .Select(game => new GameSummaryDto( game.Id, game.Name, game.Genre!.Name, game.Price, game.ReleaseDate )).AsNoTracking().ToListAsync() );

        // GET /games/1
        group.MapGet("/{id}", async (int id, GameStoreContext dbContext) =>
        {
            var game = await dbContext.Games.FindAsync(id);

            return game is null ? Results.NotFound() : Results.Ok(
                new GameDetailsDto(
                    game.Id,
                    game.Name,
                    game.GenreId,
                    game.Price,
                    game.ReleaseDate
                )
            );
        }).WithName(EndpointName);

        group.MapPost("/", async (CreateGameDto newGame, GameStoreContext dbContext) =>
        {
            Game game = new()
            {
                Name = newGame.Name,
                GenreId = newGame.GenreId,
                Price = newGame.Price,
                ReleaseDate = newGame.ReleaseDate
            };

            // Keep track
            dbContext.Games.Add(game);
            await dbContext.SaveChangesAsync();

            GameDetailsDto GameSummaryDto = new(
                game.Id,
                game.Name,
                game.GenreId,
                game.Price,
                game.ReleaseDate
            );

            return Results.CreatedAtRoute(EndpointName, new {id = GameSummaryDto.Id}, game);
        });

        // PUT /games/1
        group.MapPut("/{id}", async (int id, UpdateGameDto updatedGame, GameStoreContext dbContext) =>
        {
            var existingGame = await dbContext.Games.FindAsync(id);

            if (existingGame is null)
            {
                return Results.NotFound();
            }

            existingGame.Name = updatedGame.Name;
            existingGame.GenreId = updatedGame.GenreId;
            existingGame.Price = updatedGame.Price;
            existingGame.ReleaseDate = updatedGame.ReleaseDate;

            await dbContext.SaveChangesAsync();

            return Results.NoContent();
        });

        // DELETE /games/1
        group.MapDelete("/{id}", (int id) =>
        {
            games.RemoveAll(game => game.Id == id);

            return Results.NoContent();
        });
    } 
}
