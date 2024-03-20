using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjetCSharp.Models;

namespace ProjetCSharp.Data
{
    public class ProjetCSharpContext : DbContext
    {
        public ProjetCSharpContext (DbContextOptions<ProjetCSharpContext> options)
            : base(options)
        {
        }

        public DbSet<ProjetCSharp.Models.NombreVentes> NombreVentes { get; set; } = default!;
        public DbSet<ProjetCSharp.Models.Consoles> Consoles { get; set; } = default!;

        protected override void OnConfiguring(DbContextOptionsBuilder options) =>
       options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=ProjetCSharp.Data;Trusted_Connection=True");
    }
}
