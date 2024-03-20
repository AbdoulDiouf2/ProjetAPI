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
    public class DeleteModel : PageModel
    {
        private readonly ProjetCSharp.Data.ProjetCSharpContext _context;

        public DeleteModel(ProjetCSharp.Data.ProjetCSharpContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nombreventes = await _context.NombreVentes.FindAsync(id);
            if (nombreventes != null)
            {
                NombreVentes = nombreventes;
                _context.NombreVentes.Remove(NombreVentes);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
