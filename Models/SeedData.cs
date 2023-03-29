using Microsoft.EntityFrameworkCore;
using ShowtimeManager.Data;

namespace ShowtimeManager.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ShowtimeManagerContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<ShowtimeManagerContext>>()))
            {
                if (context == null || context.Band == null)
                {
                    throw new ArgumentNullException("Null ShowtimeManagerContext");
                }

     
                if (context.Band.Any())
                {
                    return;   
                }

                context.Band.AddRange(
                    new Band
                    {
                        BandName = "XweaponX",
                        ShowTime = DateTime.Parse("2023-2-12"),
                        Genre = "Hardcore",
                        TicketPrice = 20.25
                    },

                    new Band
                    {
                        BandName = "Mutilatred ",
                        ShowTime = DateTime.Parse("2023-3-13"),
                        Genre = "Death Metal",
                        TicketPrice = 20.25
                    },

                    new Band
                    {
                        BandName = "Vomit Forth",
                        ShowTime = DateTime.Parse("2023-4-23"),
                        Genre = "Death Metal",
                        TicketPrice = 20.75
                    },

                    new Band
                    {
                        BandName = "Gates to Hell",
                        ShowTime = DateTime.Parse("2023-5-15"),
                        Genre = "Metalcore",
                        TicketPrice = 20.75
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
