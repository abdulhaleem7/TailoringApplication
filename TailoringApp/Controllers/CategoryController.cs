using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TailoringApp.Dto;
using TailoringApp.Interface.IService;

namespace TailoringApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public CategoryController(ICategoryService categoryService, IWebHostEnvironment webHostEnvironment)
        {
            _categoryService = categoryService;
            _webHostEnvironment = webHostEnvironment;
        }
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromForm]CategoryRequestModel model)
        {
            var category = await _categoryService.Create(model);
            if (category.Status == false)
            {
                return BadRequest(category);
            }
            return Ok(category);
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var category = await _categoryService.GetAll();
            if (category.Status == false)
            {
                return BadRequest(category);
            }
            return Ok(category);
        }
        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var category = await _categoryService.Get(id);
            if (category.Status == false)
            {
                return BadRequest(category);
            }
            return Ok(category);
        }
       
    }
}
