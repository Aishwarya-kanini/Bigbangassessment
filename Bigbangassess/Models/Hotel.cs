using System.ComponentModel.DataAnnotations;

namespace Bigbangassess.Models
{
    public class Hotel
    {
        [Key]
        public int hotelId { get; set; }

        public string ? hotelName { get; set; }

        public string ? hotelAddress { get; set; }

        public string ? hotelLocation { get; set; }

        public int hotelRatings { get; set; }

        public string ? hotelContact { get; set; }

        public virtual ICollection<Room>? Rooms { get; set; }

        public virtual ICollection<Staff> ?Staffs { get; set;}

        public virtual ICollection<Customer>? Customer { get; set; }    
    }
}
