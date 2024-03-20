using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

using ClientProjet.API;

namespace ClientProjet.Pages.MesConsoles
{
    public class CreateModel : PageModel
    {
        private readonly IConsolesClient _client;


        public CreateModel(IConsolesClient client)
        {
            _client = client;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Consoles Consoles { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _client.Consoles.Add(Consoles);
            await _client.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
