using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ShowtimeManager.Data;
using ShowtimeManager.Models;

namespace ShowtimeManager.Pages.Bands
{
    public class EditModel : PageModel
    {
        private readonly ShowtimeManager.Data.ShowtimeManagerContext _context;

        public EditModel(ShowtimeManager.Data.ShowtimeManagerContext context)
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

            var band =  await _context.Band.FirstOrDefaultAsync(m => m.Id == id);
            if (band == null)
            {
                return NotFound();
            }
            Band = band;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Band).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BandExists(Band.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool BandExists(int id)
        {
          return (_context.Band?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
