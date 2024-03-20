using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClientProjet.API;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

using ClientProjet.API;

namespace ClientProjet.Pages.NombreDeVente
{
    public class DeleteModel : PageModel
    {
        private readonly IConsolesClient _client;

        public DeleteModel(IConsolesClient client)
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

            var nombreventes = await _client.NombreVentes.FirstOrDefaultAsync(m => m.Id == id);

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

            var nombreventes = await _client.NombreVentes.FindAsync(id);
            if (nombreventes != null)
            {
                NombreVentes = nombreventes;
                _client.NombreVentes.Remove(NombreVentes);
                await _client.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
