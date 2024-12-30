using Identity_.Data;
using Identity_.Models;
using Identity_.Services;
using Microsoft.AspNetCore.Mvc;

namespace Identity_.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly PasswordHasherService _passwordHasher;

        public UserController(AppDbContext context, PasswordHasherService passwordHasher)
        {
            _context = context;
            _passwordHasher = passwordHasher;
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] User user)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (_context.Users.Any(u => u.Email == user.Email))
                return Conflict("Email already exists.");

            user.PasswordHash = _passwordHasher.HashPassword(user.PasswordHash);
            _context.Users.Add(user);
            _context.SaveChanges();

            return Ok(new { message = "User registered successfully." });
        }
    }



}