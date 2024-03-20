using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProjetCSharp.Data;
using ProjetCSharp.Models;

namespace ClientProjet.Pages.MesConsoles
{
    public class IndexModel : PageModel
    {
        private readonly ProjetCSharp.Data.ProjetCSharpContext _context;

        public IndexModel(ProjetCSharp.Data.ProjetCSharpContext context)
        {
            _context = context;
        }

        public IList<Consoles> Consoles { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Consoles = await _context.Consoles.ToListAsync();
        }
    }
}
