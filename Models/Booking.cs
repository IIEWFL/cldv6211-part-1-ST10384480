using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ST10384480_CLDV_Part1.Models
{
    public class Booking
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string CustomerName { get; set; }

        [Required]
        public int NumberOfSeats { get; set; }

        [ForeignKey("Event")]
        public int EventId { get; set; }

        public Event? Event { get; set; }
    }
}