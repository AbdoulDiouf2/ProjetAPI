using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

using ClientProjet.API;

namespace ClientProjet.Pages.NombreDeVente
{
    public class CreateModel : PageModel
    {
        private readonly IConsolesClient _client;

        public CreateModel(IConsolesClient client)
        {
            _client = client;
        }

        public SelectList ConsoleList { get; set; }
        /*
        public IActionResult OnGet()
        {
            return Page();
        }*/

        public async Task<IActionResult> OnGetAsync()
        {
            var consoles = await _client.ConsolesAllAsync();
            ConsoleList = new SelectList(consoles, "Id", "Name");
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

            try
            {
                await _client.NombreVentesPOSTAsync(NombreVentes);
            }
            catch (Exception ex)
            {
                return RedirectToPage("./Index");
            }
            return RedirectToPage("./Index");
        }
    }
}
