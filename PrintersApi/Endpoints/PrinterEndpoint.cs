using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

public static class PrinterEndpoints 
{
    public static void MapPrinterEndpoints(this IEndpointRouteBuilder routes)
    {
        routes.MapGet("/printers", async (AppDbContext dbContext) => await dbContext.Printers.ToListAsync());

        routes.MapGet("/printers/{id}", async (int id, AppDbContext dbContext) => await dbContext.Printers.FindAsync(id)
            is Printer printer
            ? Results.Ok(printer)
            : Results.NotFound());

        routes.MapPost("/printers", async (Printer printer, AppDbContext dbContext) =>
        {
            dbContext.Printers.Add(printer);
            await dbContext.SaveChangesAsync();
            return Results.Created($"/printers/{printer.Id}", printer);
        });

        routes.MapPut("/printers/{id}", async (int id, Printer printerAtualizada, AppDbContext dbContext) =>
        {
            var printer = await dbContext.Printers.FindAsync(id);
            if (printer is null) return Results.NotFound();

            printer.Ip = printerAtualizada.Ip;
            printer.Local = printerAtualizada.Local;
            printer.Setor = printerAtualizada.Setor;
            printer.Senha = printerAtualizada.Senha;
            printer.Nome = printerAtualizada.Nome;

            await dbContext.SaveChangesAsync();
            return Results.NoContent();
        });

        routes.MapDelete("/printers/{id}", async (int id, AppDbContext dbContext) =>
        {
            if (await dbContext.Printers.FindAsync(id) is Printer printer)
            {
                dbContext.Remove(printer);
                await dbContext.SaveChangesAsync();
                return Results.NoContent();
            }
            return Results.NotFound();
        });
    }
}