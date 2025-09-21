using EmployeePortalApi.Data;
using EmployeePortalApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeePortalApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly EmployeePortalContext _context;

        public UsersController(EmployeePortalContext context)
        {
            _context = context;
        }

        // GET: api/users  (Admin only)
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers([FromQuery] string? role = null)
        {
            var users = _context.Users.AsQueryable();
            if (!string.IsNullOrEmpty(role))
                users = users.Where(u => u.Role == role);

            return await users.ToListAsync();
        }

        // POST: api/users (Admin only)
        [HttpPost]
        public async Task<ActionResult<User>> CreateUser(User user)
        {
            if (string.IsNullOrWhiteSpace(user.Username) || string.IsNullOrWhiteSpace(user.Role))
                return BadRequest("Username and Role are required.");

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetUsers), new { id = user.Id }, user);
        }
    }
}
