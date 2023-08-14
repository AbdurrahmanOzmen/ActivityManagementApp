using Business.Abstract;
using Business.Dto.Activity;
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
    public class ActivityController : Controller
    {
        private IActivityService _activityService;

        public ActivityController(IActivityService activityService)
        {
            _activityService = activityService;
        }

        [HttpGet("GetActivityList")]
        public async Task<IActionResult> GetActivityList()
        {
            var result = await _activityService.GetList();

            return Ok(result);
        }

        [HttpGet("GetActivityDetail")]
        public async Task<IActionResult> GetActivityDetail(int id)
        {
            var result = await _activityService.GetById(id);

            return Ok(result);
        }

        [HttpPost("CreateActivity")]
        public async Task<IActionResult> CreateActivity([FromBody] ActivityCreateDto request)
        {
            await _activityService.Create(request);

            return Ok();
        }


        [HttpPut("UpdateActivity")]
        public async Task<IActionResult> UpdateActivity([FromBody] ActivityUpdateDto request)
        {
            await _activityService.Update(request);

            return Ok();
        }

        [HttpDelete("DeleteActivity")]
        public async Task<IActionResult> DeleteActivity(int id)
        {
            await _activityService.Delete(id);

            return Ok();
        }
    }
}
