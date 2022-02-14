using Challenge.Core.DTOs;
using Challenge.Core.Entities;
using Challenge.Core.Interfaces;
using Challenge.Infrastructure.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace Challenge.API.Controllers
{
    [Route("api/Usuarios")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService service;

        public UserController(IUserService service)
        {
            this.service = service;
        }

        [HttpGet]
        public IActionResult GetUsers()
        {
            var response = service.GetAllUsers();
            return Ok(response);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var response = await service.GetUserByID(id);
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult> CreateUser(UserDto userDto)
        {
            var user = userDto.MapTo<User>();
            return Ok(await service.CreateUser(user));
        }

        [HttpPut]
        public async Task<ActionResult> UpdateUser(UserDto userDto)
        {
            var user = userDto.MapTo<User>();
            var userUpdate = await service.Update(user);
            var response = userUpdate.MapTo<UserDto>();
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await service.Delete(id);
            return Ok(response);
        }

    }
}
