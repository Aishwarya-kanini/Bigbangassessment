using Bigbangassess.Models;
using Microsoft.AspNetCore.Mvc;

namespace Bigbangassess.Repository
{
    public interface IRoom
    {
        Task<ActionResult<IEnumerable<Room>>> GetRooms();
        Task<ActionResult<Room>> GetRoom(int id);
        Task<IActionResult> PutRoom(int id, Room room);
        Task<ActionResult<Room>> PostRoom(Room room);
        Task<IActionResult> DeleteRoom(int id);
        Task<ActionResult<IEnumerable<HotelwithRoomModel>>> GetHotelsWithAvailableRooms(string availability = null);
        Task<ActionResult<IEnumerable<HotelModel>>> GetHotelsWithRoomsCount(string availability = null);
    }
}
