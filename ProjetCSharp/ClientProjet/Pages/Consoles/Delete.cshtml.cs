using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProjetCSharp.Data;
using ProjetCSharp.Models;

namespace ClientProjet.Pages.Consoles
{
    public class DeleteModel : PageModel
    {
        private readonly ProjetCSharp.Data.ProjetCSharpContext _context;

        public DeleteModel(ProjetCSharp.Data.ProjetCSharpContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Consoles Consoles { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consoles = await _context.Consoles.FirstOrDefaultAsync(m => m.Id == id);

            if (consoles == null)
            {
                return NotFound();
            }
            else
            {
                Consoles = consoles;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consoles = await _context.Consoles.FindAsync(id);
            if (consoles != null)
            {
                Consoles = consoles;
                _context.Consoles.Remove(Consoles);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
