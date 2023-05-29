using Microsoft.EntityFrameworkCore;

namespace Bigbangassess.Models
{
    public class HotelRoomContext: DbContext
    {
        public DbSet<Hotel>hotels { get; set; }

        public DbSet<Room> rooms { get; set; }

        public DbSet<Staff> staffs { get; set; }
        public DbSet<Customer> customers { get; set; }
        public HotelRoomContext(DbContextOptions<HotelRoomContext> options) : base(options)
        {

        }
    }
}
