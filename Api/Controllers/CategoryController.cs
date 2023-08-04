using Business.Abstract;
using Business.Dto.Category;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : Controller
    {
        private ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("GetCategoryList")]
        public async Task<IActionResult> GetCategoryList()
        {
            var result = await _categoryService.GetList();

            return Ok(result);
        }

        [HttpGet("GetCategoryDetail")]
        public async Task<IActionResult> GetCategoryDetail(int id)
        {
            var result = await _categoryService.GetById(id);

            return Ok(result);
        }

        [HttpPost("CreateCategory")]
        public async Task<IActionResult> CreateCategory([FromBody] CategoryCreateDto request)
        {
            await _categoryService.Create(request);

            return Ok();
        }
    }
}
