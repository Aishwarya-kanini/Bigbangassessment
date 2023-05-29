using System.ComponentModel.DataAnnotations;

namespace Bigbangassess.Models
{
    public class Staff
    {
        [Key] 
        public int staffId { get; set; }
        public string staffName { get; set; }

        public string ? staffGender { get; set;}

        public Hotel? Hotel { get; set; }
    }
}
