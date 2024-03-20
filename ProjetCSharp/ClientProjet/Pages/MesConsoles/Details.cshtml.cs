using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProjetCSharp.Data;
using ProjetCSharp.Models;

namespace ClientProjet.Pages.MesConsoles
{
    public class DetailsModel : PageModel
    {
        private readonly ProjetCSharp.Data.ProjetCSharpContext _context;

        public DetailsModel(ProjetCSharp.Data.ProjetCSharpContext context)
        {
            _context = context;
        }

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
    }
}
