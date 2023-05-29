using System.ComponentModel.DataAnnotations;

namespace Bigbangassess.Models
{
    public class Customer
    {
        [Key]
        public int custId { get; set; }
        public string custName { get; set; }

        [Required]
        public string email { get; set; }

        [Required]
        public string password { get; set; }

        
    }
}
