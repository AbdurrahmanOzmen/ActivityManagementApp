﻿using Api.Infrastructure.Helpers;
using Business.Abstract;
using Business.Dto.User;
using Entities.Enums;
using ESPV2.OperationManagement.Api.Infrastructure.Attributes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class UserController : Controller
    {
        private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("GetUserList")]
        [HasUserType(UserTypeEnum.Admin)]
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

        [HttpDelete("DeleteUser")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            await _userService.Delete(id);

            return Ok();
        }

        //TODO: HttpGet yerine HttpPost olacak. email ve password modelden alınacak. LoginDto oluşturulacak. İçinde email, password olacak. UpdateUser'daki parametre gibi FromBody üzerinden alınacak.
        //TODO: diğer controller lar da [Authorize] attribute eklenecek.
        [AllowAnonymous]
        [HttpGet("Login")]
        public async Task<IActionResult> Login(string email, string password)
        {
            var result = await _userService.Login(email, password);

            var claims = new Dictionary<string, object>()
            {
                { "unique_name", result.Email},
                { "user", result}
            };

            var tokenResult = new UserTokenDto
            {
                User = result,
                Token = JwtBuilderHelper.Build(claims)
            };

            return Ok(tokenResult);
        }
    }
}
