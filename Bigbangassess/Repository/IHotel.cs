using Bigbangassess.Models;

namespace Bigbangassess.Repository
{
    public interface IHotel
    {
        Task<IEnumerable<Hotel>> GetAllHotelsAsync();
        Task<Hotel> GetHotelByIdAsync(int id);
        Task<Hotel> PostHotelsAsync(Hotel hotel);
        Task<Hotel> PutHotelAsync(int id, Hotel hotel);
        Task<Hotel> DelHotelsAsync(int id);
    }
}
