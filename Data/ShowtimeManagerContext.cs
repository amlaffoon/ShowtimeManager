using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ShowtimeManager.Models;

namespace ShowtimeManager.Data
{
    public class ShowtimeManagerContext : DbContext
    {
        public ShowtimeManagerContext (DbContextOptions<ShowtimeManagerContext> options)
            : base(options)
        {
        }

        public DbSet<ShowtimeManager.Models.Band> Band { get; set; } = default!;
    }
}
