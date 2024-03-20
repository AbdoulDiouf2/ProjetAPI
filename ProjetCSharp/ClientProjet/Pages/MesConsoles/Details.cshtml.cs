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
    public class DetailsModel : PageModel
    {
        private readonly IConsolesClient _client;

        public DetailsModel(IConsolesClient client)
        {
            _client = client;
        }

        public Consoles Consoles { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consoles = await _client.Consoles.FirstOrDefaultAsync(m => m.Id == id);
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
