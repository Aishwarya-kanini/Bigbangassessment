using Bigbangassess.Models;
using Bigbangassess.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bigbangassess.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class HotelController : ControllerBase
    {
        private readonly IHotel _hotelRepo;

        public HotelController(IHotel hotelRepo)
        {
            _hotelRepo = hotelRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllHotels()
        {
            try
            {
                var hotels = await _hotelRepo.GetAllHotelsAsync();
                return Ok(hotels);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetHotelById(int id)
        {
            try
            {
                var hotel = await _hotelRepo.GetHotelByIdAsync(id);
                if (hotel == null)
                {
                    return NotFound();
                }
                return Ok(hotel);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> PostHotels([FromBody] Hotel hotel)
        {
            try
            {
                if (hotel == null)
                {
                    return BadRequest();
                }
                var addedHotel = await _hotelRepo.PostHotelsAsync(hotel);
                return CreatedAtAction(nameof(GetHotelById), new { id = addedHotel.hotelId }, addedHotel);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutHotel(int id, [FromBody] Hotel hotel)
        {
            try
            {
                if (hotel == null || hotel.hotelId != id)
                {
                    return BadRequest();
                }
                var updatedHotel = await _hotelRepo.PutHotelAsync(id, hotel);
                if (updatedHotel == null)
                {
                    return NotFound();
                }
                return Ok(updatedHotel);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DelHotels(int id)
        {
            try
            {
                var hotel = await _hotelRepo.DelHotelsAsync(id);
                if (hotel == null)
                {
                    return NotFound();
                }
                return Ok(hotel);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}

