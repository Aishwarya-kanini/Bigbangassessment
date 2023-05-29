using System.ComponentModel.DataAnnotations;

namespace Bigbangassess.Models
{
    public class Room
    {
        [Key]
        public int roomId { get; set; }

        public string? roomType { get; set; }

        public string? Availability { get; set; }

        public int PricePerDay { get; set; }

        public Hotel? Hotel { get; set; }
    }
}
