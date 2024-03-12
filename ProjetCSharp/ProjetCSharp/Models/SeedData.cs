using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ProjetCSharp.Data;
using System;
using System.Linq;
namespace ProjetCSharp.Models;
public static class SeedData // Ajout d’une nouvelle classe SeedData dans Models pour créer la base et ajouter un film si besoin
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new ProjetCSharpContext(
        serviceProvider.GetRequiredService<
        DbContextOptions<ProjetCSharpContext>>()))
        {
            context.Database.EnsureCreated();
            // S’il y a déjà des consoles dans la base
            if (context.Consoles.Any())
            {
                return; // On ne fait rien
            }
            // Sinon on en ajoute un
            context.Consoles.AddRange(
            new Consoles
            {
                Const="Sony",
                Name = "PS5",

            }

            );
            context.SaveChanges();
        }
    }
}