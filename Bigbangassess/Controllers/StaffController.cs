using Bigbangassess.Models;
using Bigbangassess.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bigbangassess.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class StaffController : ControllerBase
    {
        private readonly IStaff _staffRepo;

        public StaffController(IStaff staffRepo)
        {
            _staffRepo = staffRepo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Staff>>> GetStaffs()
        {
            try
            {
                return await _staffRepo.GetStaffs();
            }
            catch (Exception ex)
            {
                return BadRequest("Failed to get staffs. Error message: " + ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Staff>> GetStaffById(int id)
        {
            try
            {
                var staff = await _staffRepo.GetStaffById(id);
                if (staff == null)
                {
                    return NotFound("Staff not found with ID " + id);
                }
                return staff;
            }
            catch (Exception ex)
            {
                return BadRequest("Failed to get staff with ID " + id + ". Error message: " + ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutStaff(int id, Staff staff)
        {
            try
            {
                var result = await _staffRepo.PutStaff(id,staff);
                if (result == null)
                {
                    return NotFound("Staff not found with ID " + id);
                }
                return Ok("Staff with ID " + id + " has been updated successfully");
            }
            catch (Exception ex)
            {
                return BadRequest("Failed to update staff with ID " + id + ". Error message: " + ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Staff>> PostStaff(Staff staff)
        {
            try
            {
                var result = await _staffRepo.PostStaff(staff);
                if (result == null)
                {
                    return BadRequest("Failed to add new staff");
                }
                return Ok("New staff has been added successfully");
            }
            catch (Exception ex)
            {
                return BadRequest("Failed to add new staff. Error message: " + ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStaff(int id)
        {
            try
            {
                var result = await _staffRepo.DeleteStaff(id);
                if (result == null)
                {
                    return NotFound("Staff not found with ID " + id);
                }
                return Ok("Staff with ID " + id + " has been deleted successfully");
            }
            catch (Exception ex)
            {
                return BadRequest("Failed to delete staff with ID " + id + ". Error message: " + ex.Message);
            }

        }
    }
}

