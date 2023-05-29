using Bigbangassess.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bigbangassess.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly HotelRoomContext _context;

        public CustomerController(HotelRoomContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> GetUsers()
        {
            if (_context.customers == null)
            {
                return NotFound();
            }
            return await _context.customers.ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetUser(int id)
        {
            if (_context.customers == null)
            {
                return NotFound();
            }
            var user = await _context.customers.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, Customer user)
        {
            if (id != user.custId)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }
        [HttpPost]
        public async Task<ActionResult<Customer>> PostUser(Customer user)
        {
            if (_context.customers == null)
            {
                return Problem("Entity set 'ProCatContext.Users'  is null.");
            }
            _context.customers.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = user.custId }, user);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            if (_context.customers == null)
            {
                return NotFound();
            }
            var user = await _context.customers.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.customers.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserExists(int id)
        {
            return (_context.customers?.Any(e => e.custId == id)).GetValueOrDefault();
        }
    }
}

