using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProjetCSharp.Data;
using ProjetCSharp.Models;

namespace ClientProjet.Pages.NombreDeVente
{
    public class IndexModel : PageModel
    {
        private readonly ProjetCSharp.Data.ProjetCSharpContext _context;

        public IndexModel(ProjetCSharp.Data.ProjetCSharpContext context)
        {
            _context = context;
        }

        public IList<NombreVentes> NombreVentes { get;set; } = default!;

        public async Task OnGetAsync()
        {
            NombreVentes = await _context.NombreVentes.ToListAsync();
        }
    }
}
