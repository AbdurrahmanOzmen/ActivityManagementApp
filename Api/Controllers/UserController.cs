using Business.Abstract;
using Business.Dto.User;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("GetUserList")]
        public async Task<IActionResult> GetUserList()
        {
            var result = await _userService.GetList();

            return Ok(result);
        }

        [HttpGet("GetUserDetail")]
        public async Task<IActionResult> GetUserDetail(int id)
        {
            var result = await _userService.GetById(id);

            return Ok(result);
        }

        [HttpPost("CreateUser")]
        public async Task<IActionResult> CreateCUser([FromBody] UserCreateDto request)
        {
            await _userService.Create(request);

            return Ok();
        }

        [HttpPut("UpdateUser")]
        public async Task<IActionResult> UpdateUser([FromBody] UserUpdateDto request)
        {
            await _userService.Update(request);

            return Ok();
        }
    }
}
