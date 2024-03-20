using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProjetCSharp.Data;
using ProjetCSharp.Models;

namespace ClientProjet.Pages.NombreDeVente
{
    public class CreateModel : PageModel
    {
        private readonly ProjetCSharp.Data.ProjetCSharpContext _context;

        public CreateModel(ProjetCSharp.Data.ProjetCSharpContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public NombreVentes NombreVentes { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.NombreVentes.Add(NombreVentes);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
