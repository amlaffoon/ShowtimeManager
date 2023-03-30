using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShowtimeManager.Models
{
    public class Band
    {
        public int Id { get; set; }
        [Display(Name = "Artist")]
        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string? BandName { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Showtime")]
        public DateTime ShowTime { get; set; }
        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
        [Required]
        [StringLength(30)]
        public string? Genre { get; set; }
        [Display(Name = "Ticket Price")]
        [Range(1, 100)]
        [DataType(DataType.Currency)]
        public double TicketPrice { get; set; }
    }
}
