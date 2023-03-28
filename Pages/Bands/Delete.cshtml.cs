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
    public class DeleteModel : PageModel
    {
        private readonly ShowtimeManager.Data.ShowtimeManagerContext _context;

        public DeleteModel(ShowtimeManager.Data.ShowtimeManagerContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Band Band { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Band == null)
            {
                return NotFound();
            }

            var band = await _context.Band.FirstOrDefaultAsync(m => m.Id == id);

            if (band == null)
            {
                return NotFound();
            }
            else 
            {
                Band = band;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Band == null)
            {
                return NotFound();
            }
            var band = await _context.Band.FindAsync(id);

            if (band != null)
            {
                Band = band;
                _context.Band.Remove(Band);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
