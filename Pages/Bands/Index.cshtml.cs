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
    public class IndexModel : PageModel
    {
        private readonly ShowtimeManager.Data.ShowtimeManagerContext _context;

        public IndexModel(ShowtimeManager.Data.ShowtimeManagerContext context)
        {
            _context = context;
        }

        public IList<Band> Band { get;set; } = default!;

        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }

        public SelectList? Genres { get; set; }


        [BindProperty(SupportsGet = true)]
        public string MusicGenre { get; set; }

        public async Task OnGetAsync()
        {
            IQueryable<string> genreQuery = from m in _context.Band
                                            orderby m.Genre
                                            select m.Genre;
            var bands = from b in _context.Band
                         select b;
            if (!string.IsNullOrEmpty(SearchString))
            {
                bands = bands.Where(s => s.BandName.Contains(SearchString));
            }

            if (!string.IsNullOrEmpty(MusicGenre))
            {
                bands = bands.Where(x => x.Genre == MusicGenre);
            }
            Genres = new SelectList(await genreQuery.Distinct().ToListAsync());

            Band = await bands.ToListAsync();
        }
    }
}
