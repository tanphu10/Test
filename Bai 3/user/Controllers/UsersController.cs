using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using user.Entities;
using user.Models;

namespace user.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly TestDbContext _context;
        public UsersController(TestDbContext context)
        {
            _context = context;
        }
        [HttpPost]
        public async Task<IActionResult> CreateUserAsync([FromBody] CreateUser model)
        {

            var result = await _context.AddAsync(model);
            return Ok();
        }
        //[HttpGet]
        //public async Task<List<User>> GetAll()
        //{
        //    var user = await _context.Find();
        //    return Ok(user);
        //}
        //[HttpDelete]
        //public async Task<IActionResult> DeleteAsync([FromQuery] Guid Id)
        //{
          
        //    var result = await _context.d();
        //    return result > 0 ? Ok() : BadRequest();
        //}

    }
}
