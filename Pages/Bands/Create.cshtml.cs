using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShowtimeManager.Data;
using ShowtimeManager.Models;

namespace ShowtimeManager.Pages.Bands
{
    public class CreateModel : PageModel
    {
        private readonly ShowtimeManager.Data.ShowtimeManagerContext _context;

        public CreateModel(ShowtimeManager.Data.ShowtimeManagerContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Band Band { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Band == null || Band == null)
            {
                return Page();
            }

            _context.Band.Add(Band);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
