using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

public static class TonnerEndpoints 
{
    public static void MapTonnerEndpoints(this IEndpointRouteBuilder routes)
    {
        routes.MapGet("/tonners", async (AppDbContext dbContext) => await dbContext.Printers.ToListAsync());

        routes.MapGet("/tonners/{id}", async (int id, AppDbContext dbContext) => await dbContext.Tonners.FindAsync(id)
            is Tonner tonner
            ? Results.Ok(tonner)
            : Results.NotFound());

        routes.MapPost("/tonners", async (Tonner tonner, AppDbContext dbContext) =>
        {
            dbContext.Tonners.Add(tonner);
            await dbContext.SaveChangesAsync();
            return Results.Created($"/tonners/{tonner.Id}", tonner);
        });

        routes.MapPut("/tonners/{id}", async (int id, Tonner tonnerAtualizado, AppDbContext dbContext) =>
        {
            var tonner = await dbContext.Tonners.FindAsync(id);
            if (tonner is null) return Results.NotFound();

            tonner.Printer = tonnerAtualizado.Printer;
            tonner.Tipo = tonnerAtualizado.Tipo;
            tonner.Cor = tonnerAtualizado.Cor;
            tonner.SelbId = tonnerAtualizado.SelbId;

            await dbContext.SaveChangesAsync();
            return Results.NoContent();
        });

        routes.MapDelete("/tonners/{id}", async (int id, AppDbContext dbContext) =>
        {
            if (await dbContext.Tonners.FindAsync(id) is Tonner tonner)
            {
                dbContext.Remove(tonner);
                await dbContext.SaveChangesAsync();
                return Results.NoContent();
            }
            return Results.NotFound();
        });
    }
}