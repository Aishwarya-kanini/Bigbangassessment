using Bigbangassess.Models;
using Microsoft.EntityFrameworkCore;

namespace Bigbangassess.Repository
{
    public class HotelRepo:IHotel
    {
        private readonly HotelRoomContext hotelRoomContext;

        public HotelRepo(HotelRoomContext context)
        {
            this.hotelRoomContext = context;
        }
        public async Task<IEnumerable<Hotel>> GetAllHotelsAsync()
        {
            try
            {
                return await hotelRoomContext.hotels.Include(x => x.Rooms).ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<Hotel> GetHotelByIdAsync(int id)
        {
            try
            {
                return await hotelRoomContext.hotels.Include(x => x.Rooms).FirstOrDefaultAsync(x => x.hotelId == id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<Hotel> PostHotelsAsync(Hotel hotel)
        {
            try
            {
                hotelRoomContext.hotels.Add(hotel);
                await hotelRoomContext.SaveChangesAsync();
                return hotel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<Hotel> PutHotelAsync(int id, Hotel hotel)
        {
            try
            {
                hotelRoomContext.Entry(hotel).State = EntityState.Modified;
                await hotelRoomContext.SaveChangesAsync();
                return hotel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<Hotel> DelHotelsAsync(int id)
        {
            try
            {
                Hotel del = await hotelRoomContext.hotels.FirstOrDefaultAsync(x => x.hotelId == id);
                hotelRoomContext.hotels.Remove(del);
                await hotelRoomContext.SaveChangesAsync();
                return del;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
