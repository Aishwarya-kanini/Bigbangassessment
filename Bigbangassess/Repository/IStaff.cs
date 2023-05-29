using Bigbangassess.Models;
using Microsoft.AspNetCore.Mvc;

namespace Bigbangassess.Repository
{
    public interface IStaff
    {
        Task<ActionResult<IEnumerable<Staff>>> GetStaffs();
        Task<ActionResult<Staff>> GetStaffById(int id);
        Task<IActionResult> PutStaff(int id, Staff staff);
        Task<ActionResult<Staff>> PostStaff(Staff staff);
        Task<IActionResult> DeleteStaff(int id);
    }
}

