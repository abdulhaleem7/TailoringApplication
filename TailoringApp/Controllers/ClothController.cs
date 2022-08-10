using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TailoringApp.Dto;
using TailoringApp.Interface.IService;

namespace TailoringApp.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ClothController : ControllerBase
    {
        private readonly IClothService _clothService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ClothController(IClothService clothService, IWebHostEnvironment webHostEnvironment)
        {
            _clothService = clothService;
            _webHostEnvironment = webHostEnvironment;
        }
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromForm]ClothRequestModel model)
        {
            int count = 0;
            var files = HttpContext.Request.Form;
            if (files != null && files.Count > 0)
            {
                string imageDirectory = Path.Combine(_webHostEnvironment.WebRootPath, "ClothImage");
                Directory.CreateDirectory(imageDirectory);
                foreach (var file in files.Files)
                {
                    FileInfo fi = new FileInfo(file.FileName);
                    string ClothImages = Guid.NewGuid().ToString() + fi.Extension;
                    string path = Path.Combine(imageDirectory, ClothImages);
                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }

                    if (count == 0)
                    {
                        model.Picture = ClothImages;
                        count++;
                    }
                    
                }
            }
            var cloths = await _clothService.Create(model);
            if (cloths.Status == false)
            {
                return BadRequest(cloths.Message);
            }
            return Ok(cloths);
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var cloths = await _clothService.GetAll();
            if (cloths.Status == false)
            {
                return BadRequest(cloths.Message);
            }
            return Ok(cloths);
        }
        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById([FromRoute]int id)
        {
            var cloths = await _clothService.Get(id);
            if (cloths.Status == false)
            {
                return BadRequest(cloths.Message);
            }
            return Ok(cloths);
        }
        [HttpGet("GetAllClothByCategory/{id}")]
        public async Task<IActionResult> GetAllClothByCategory([FromRoute]int id)
        {
            var cloths = await _clothService.GetClothByCategoryId(id);
            if (cloths.Status == false)
            {
                return BadRequest(cloths);
            }
            return Ok(cloths);
        }

    }
}
