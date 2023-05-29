using Bigbangassess.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static Bigbangassess.Models.HotelwithRoomModel;

namespace Bigbangassess.Repository
{
    public class RoomRepo:IRoom
    {
        private readonly HotelRoomContext cont;

        public RoomRepo(HotelRoomContext context)
        {
            cont = context;
        }
        public async Task<ActionResult<IEnumerable<Room>>> GetRooms()
        {
            return await cont.rooms.Include(x => x.Hotel).ToListAsync();
        }

        public async Task<ActionResult<Room>> GetRoom(int id)
        {
            var room = await cont.rooms.FindAsync(id);
            return room;
        }

        public async Task<IActionResult> PutRoom(int id, Room room)
        {


            cont.Entry(room).State = EntityState.Modified;
            await cont.SaveChangesAsync();
            return new NoContentResult();
        }

        public async Task<ActionResult<Room>> PostRoom(Room room)
        {
            cont.rooms.Add(room);
            await cont.SaveChangesAsync();
            return new CreatedAtActionResult("GetRoom", "Rooms", new { id = room.roomId }, room);
        }

        public async Task<IActionResult> DeleteRoom(int id)
        {
            var room = await cont.rooms.FindAsync(id);
            cont.rooms.Remove(room);
            await cont.SaveChangesAsync();
            return new NoContentResult();
        }

        public async Task<ActionResult<IEnumerable<HotelwithRoomModel>>> GetHotelsWithAvailableRooms(string availability = null)
        {
            IQueryable<Hotel> query = cont.hotels.Include(h => h.Rooms);

            if (!string.IsNullOrEmpty(availability))
            {
                query = query.Where(h => h.Rooms.Any(r => r.Availability == availability));
            }

            var hotels = await query.ToListAsync();

            var result = hotels.Select(h => new HotelwithRoomModel
            {
                HotelId = h.hotelId,
                HotelName = h.hotelName,
                HotelAddress = h.hotelAddress,
                Location = h.hotelLocation,
                Ratings = h.hotelRatings,
                Contact = h.hotelContact,
                AvailableRooms = h.Rooms.Where(r => r.Availability == availability)
                                        .Select(r => new RoomDto
                                        {
                                            RoomId = r.roomId,
                                            RoomType = r.roomType,
                                            Availability = r.Availability,
                                            Price = r.PricePerDay
                                        })
                                        .ToList()
            });

            return new OkObjectResult(new { Hotels = result });
        }



        public async Task<ActionResult<IEnumerable<HotelModel>>> GetHotelsWithRoomsCount(string availability)
        {
            IQueryable<Hotel> query = cont.hotels.Include(h => h.Rooms);

            if (!string.IsNullOrEmpty(availability))
            {
                query = query.Where(h => h.Rooms.Any(r => r.Availability == availability));
            }

            var hotels = await query.ToListAsync();

            var result = hotels.Select(h => new HotelModel
            {
                hotelId = h.hotelId,
                hotelName= h.hotelName,
                hotelAddress= h.hotelAddress,
                hotelLocation = h.hotelLocation,
                hotelRatings = h.hotelRatings,
                hotelContact = h.hotelContact,
                TotalAvailableRooms = h.Rooms.Count(r => r.Availability == availability)
            });

            return new OkObjectResult(new { Hotels = result });
        }
        private bool RoomExists(int id)
        {
            return (cont.rooms?.Any(e => e.roomId == id)).GetValueOrDefault();
        }

    }
}
