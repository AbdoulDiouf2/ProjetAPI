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
    public class IndexModel : PageModel
    {
        private readonly IConsolesClient _client;

        public IndexModel(IConsolesClient client)
        {
            _client = client;
        }

        public IList<NombreVentes> NombreVentes { get;set; } = default!;
        public Dictionary<int, string> ConsoleNames { get; set; } = new Dictionary<int, string>();

        public async Task OnGetAsync()
        {
            NombreVentes = (await _client.NombreVentesAllAsync()).ToList();

            var consoles = await _client.ConsolesAllAsync();
            ConsoleNames = consoles.ToDictionary(c => c.Id, c => c.Name);
        }

    }
}
