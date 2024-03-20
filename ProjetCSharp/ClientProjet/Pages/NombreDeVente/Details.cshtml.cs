using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

using ClientProjet.API;

namespace ClientProjet.Pages.NombreDeVente
{
    public class DetailsModel : PageModel
    {
        private readonly IConsolesClient _client;

        public DetailsModel(IConsolesClient client)
        {
            _client = client;
        }

        public NombreVentes NombreVentes { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            NombreVentes = await _client.NombreVentesGETAsync(id.Value);
            if (NombreVentes == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
