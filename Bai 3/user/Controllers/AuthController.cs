using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Text.Json;
using user.Entities;
using user.Models;
using user.Repositories;

namespace user.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly TestDbContext _context;
        private readonly IPasswordHasher<User> _passwordHasher;

        public AuthController(IUnitOfWork unitOfWork, IPasswordHasher<User> passwordHasher)
        {
            _unitOfWork = unitOfWork;
            _passwordHasher = passwordHasher;
        }
        [HttpPost]
        public async Task<ActionResult<string>> Login([FromBody] login request)
        {
            //Authentication
            if (request == null)
            {
                return BadRequest("Invalid request");
            }
            var user = await _unitOfWork.Users.FindEmail(request.Email);

            if (user == null)
            {
                return Unauthorized();
            }

            // Verify the password
            var passwordVerificationResult = _passwordHasher.VerifyHashedPassword(user, user.Password, request.Password);
            if (passwordVerificationResult != PasswordVerificationResult.Success)
            {
                return Unauthorized("Invalid email or password.");
            }

            // Authentication successful
            // You can add token generation logic here if needed
            return Ok("Login successful");
        }
    }
}
