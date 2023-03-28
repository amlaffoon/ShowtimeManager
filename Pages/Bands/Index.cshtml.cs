using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ShowtimeManager.Data;
using ShowtimeManager.Models;

namespace ShowtimeManager.Pages.Bands
{
    public class IndexModel : PageModel
    {
        private readonly ShowtimeManager.Data.ShowtimeManagerContext _context;

        public IndexModel(ShowtimeManager.Data.ShowtimeManagerContext context)
        {
            _context = context;
        }

        public IList<Band> Band { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Band != null)
            {
                Band = await _context.Band.ToListAsync();
            }
        }
    }
}
