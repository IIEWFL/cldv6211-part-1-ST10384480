using System.ComponentModel.DataAnnotations;

namespace ST10384480_CLDV_Part1.Models
{
    public class Venue
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Location { get; set; }

        [Required]
        public int Capacity { get; set; }

        public string? ImagePath { get; set; }

        public ICollection<Event>? Events { get; set; }
    }
}