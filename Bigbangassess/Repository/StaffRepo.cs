using Bigbangassess.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bigbangassess.Repository
{
    public class StaffRepo : IStaff
    {
        private readonly HotelRoomContext cont;

        public StaffRepo(HotelRoomContext context)
        {
            cont = context;
        }
        public async Task<ActionResult<IEnumerable<Staff>>> GetStaffs()
        {
            return await cont.staffs.Include(x => x.Hotel).ToListAsync();
        }

        public async Task<ActionResult<Staff>> GetStaffById(int id)
        {
            var staff = await cont.staffs.FindAsync(id);
            return staff;
        }

        public async Task<IActionResult> PutStaff(int id, Staff staff)
        {


            cont.Entry(staff).State = EntityState.Modified;
            await cont.SaveChangesAsync();
            return new NoContentResult();
        }

        public async Task<ActionResult<Staff>> PostStaff(Staff staff)
        {
            cont.staffs.Add(staff);
            await cont.SaveChangesAsync();
            return new CreatedAtActionResult("GetStaff", "Staffs", new { id = staff.staffId }, staff);
        }

        public async Task<IActionResult> DeleteStaff(int id)
        {
            var staff = await cont.staffs.FindAsync(id);
            cont.staffs.Remove(staff);
            await cont.SaveChangesAsync();
            return new NoContentResult();
        }

    }
}
