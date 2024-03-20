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
    public class IndexModel : PageModel
    {
        private readonly IConsolesClient _client;

        public IndexModel(IConsolesClient client)
        {
            _client = client;
        }

        public IList<Consoles> Consoles { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Consoles = (await _client.ConsolesAllAsync()).ToList();
        }
    }
}
