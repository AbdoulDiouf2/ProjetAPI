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
    public class DetailsModel : PageModel
    {
        private readonly ProjetCSharp.Data.ProjetCSharpContext _context;

        public DetailsModel(ProjetCSharp.Data.ProjetCSharpContext context)
        {
            _context = context;
        }

        public NombreVentes NombreVentes { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nombreventes = await _context.NombreVentes.FirstOrDefaultAsync(m => m.Id == id);
            if (nombreventes == null)
            {
                return NotFound();
            }
            else
            {
                NombreVentes = nombreventes;
            }
            return Page();
        }
    }
}
