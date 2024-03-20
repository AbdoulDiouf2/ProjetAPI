using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

using ClientProjet.API;

namespace ClientProjet.Pages.NombreDeVente
{
    public class EditModel : PageModel
    {
        private readonly IConsolesClient _client;

        public EditModel(IConsolesClient client)
        {
            _client = client;
        }

        [BindProperty]
        public NombreVentes NombreVentes { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nombreventes =  await _client.NombreVentes.FirstOrDefaultAsync(m => m.Id == id);
            if (nombreventes == null)
            {
                return NotFound();
            }
            NombreVentes = nombreventes;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _client.Attach(NombreVentes).State = EntityState.Modified;

            try
            {
                await _client.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NombreVentesExists(NombreVentes.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool NombreVentesExists(int id)
        {
            return _context.NombreVentes.Any(e => e.Id == id);
        }
    }
}
