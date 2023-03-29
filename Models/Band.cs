using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShowtimeManager.Models
{
    public class Band
    {
        public int Id { get; set; }
        [Display(Name = "Artist")]
        public string? BandName { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Showtime")]
        public DateTime ShowTime { get; set; }
        public string? Genre { get; set; }
        [Display(Name = "Ticket Price")]
        public double TicketPrice { get; set; }
    }
}
