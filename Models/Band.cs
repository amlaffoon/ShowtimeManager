using System.ComponentModel.DataAnnotations;

namespace ShowtimeManager.Models
{
    public class Band
    {
        public int Id { get; set; }
        public string? BandName { get; set; }
        [DataType(DataType.Date)]
        public DateTime ShowTime { get; set; }
        public string? Genre { get; set; }
        public double TicketPrice { get; set; }
    }
}
