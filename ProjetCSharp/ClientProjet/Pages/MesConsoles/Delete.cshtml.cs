using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

using ClientProjet.API;

namespace ClientProjet.Pages.MesConsoles
{
    public class DeleteModel : PageModel
    {
        private readonly IConsolesClient _client;

        public DeleteModel(IConsolesClient client)
        {
            _client = client;
        }

        [BindProperty]
        public Consoles Consoles { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consoles = await _client.ConsolesGETAsync(id.Value);

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

            try
            {
                await _client.ConsolesDELETEAsync(id.Value);
            }
            catch (Exception ex)
            {
                return RedirectToPage("./Index");
            }
            return RedirectToPage("./Index");
        }
    }
}
