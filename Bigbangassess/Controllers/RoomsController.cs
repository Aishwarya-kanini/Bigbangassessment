using Bigbangassess.Models;
using Bigbangassess.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bigbangassess.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomsController : ControllerBase
    {
        private readonly IRoom _roomRepo;

        public RoomsController(IRoom roomRepo)
        {
            _roomRepo = roomRepo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Room>>> GetRooms()
        {
            try
            {
                return await _roomRepo.GetRooms();
            }
            catch (Exception ex)
            {
                return BadRequest("Failed to get rooms. Error message: " + ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Room>> GetRoom(int id)
        {
            try
            {
                var room = await _roomRepo.GetRoom(id);
                if (room == null)
                {
                    return NotFound("Room not found with ID " + id);
                }
                return room;
            }
            catch (Exception ex)
            {
                return BadRequest("Failed to get room with ID " + id + ". Error message: " + ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutRoom(int id, Room room)
        {
            try
            {
                var result = await _roomRepo.PutRoom(id, room);
                if (result == null)
                {
                    return NotFound("Room not found with ID " + id);
                }
                return Ok("Room with ID " + id + " has been updated successfully");
            }
            catch (Exception ex)
            {
                return BadRequest("Failed to update room with ID " + id + ". Error message: " + ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Room>> PostRoom(Room room)
        {
            try
            {
                var result = await _roomRepo.PostRoom(room);
                if (result == null)
                {
                    return BadRequest("Failed to create new room");
                }
                return Ok("New room has been created successfully");
            }
            catch (Exception ex)
            {
                return BadRequest("Failed to create new room. Error message: " + ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoom(int id)
        {
            try
            {
                var result = await _roomRepo.DeleteRoom(id);
                if (result == null)
                {
                    return NotFound("Room not found with ID " + id);
                }
                return Ok("Room with ID " + id + " has been deleted successfully");
            }
            catch (Exception ex)
            {
                return BadRequest("Failed to delete room with ID " + id + ". Error message: " + ex.Message);
            }
        }

        [HttpGet("hotels/available-rooms")]
        public async Task<ActionResult<IEnumerable<HotelwithRoomModel>>> GetHotelsWithAvailableRooms(string availability)
        {
            try
            {
                return await _roomRepo.GetHotelsWithAvailableRooms(availability);
            }
            catch (Exception ex)
            {
                return BadRequest("Failed to get hotels with available rooms. Error message: " + ex.Message);
            }
        }

        [HttpGet("hotels/rooms-count")]
        public async Task<ActionResult<IEnumerable<HotelModel>>> GetHotelsWithRoomsCount(string availability)
        {
            try
            {
                return await _roomRepo.GetHotelsWithRoomsCount(availability);
            }
            catch (Exception ex)
            {
                return BadRequest("Failed to get hotels with room counts. Error message: " + ex.Message);
            }
        }

    }
}

