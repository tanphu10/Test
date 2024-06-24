using AutoMapper;
using Azure.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using user.Entities;
using user.Models;
using user.Repositories;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace user.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UsersController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpPost]
        public async Task<IActionResult> CreateUserAsync([FromBody] User model)
        {
            var userId = Guid.NewGuid();
            model.Id = userId;
            _unitOfWork.Users.Add(model);
            return Ok();
        }
        [HttpGet]
        public async Task<ActionResult<List<User>>> GetAll()
        {
            var result = await _unitOfWork.Users.GetAllAsync();
            return Ok(result);
        }
        [HttpGet("user/{userid}")]
        public async Task<ActionResult<User>> GetUserId(Guid userid)
        {
            var data = await _unitOfWork.Users.GetByIdAsync(userid);
            return Ok(data);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteAsync([FromBody] Guid[] ids)
        {
            foreach (var id in ids)
            {
                var location = await _unitOfWork.Users.GetByIdAsync(id);
                if (location == null) return NotFound();
                _unitOfWork.Users.Remove(location);

            }
            var result = await _unitOfWork.CompleteAsync();
            return result > 0 ? Ok() : BadRequest();
        }
        [HttpPut]
        public async Task<IActionResult> UpdateUser(Guid id, [FromBody] UserDto model)
        {
            var user = await _unitOfWork.Users.GetByIdAsync(id);
            if (user == null) return NotFound();
            _mapper.Map(model, user);
            var result = await _unitOfWork.CompleteAsync();
            return result > 0 ? Ok() : BadRequest();
        }

    }
}
