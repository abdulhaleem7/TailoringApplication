using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TailoringApp.Dto;
using TailoringApp.Interface.IService;

namespace TailoringApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DesignController : ControllerBase
    {
        private readonly IDesignService _designService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public DesignController(IDesignService designService, IWebHostEnvironment webHostEnvironment)
        {
            _designService = designService;
            _webHostEnvironment = webHostEnvironment;
        }
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromForm]DesignRequestModel model)
        {
            int count = 0;
            var files = HttpContext.Request.Form;
            if (files != null && files.Count > 0)
            {
                string imageDirectory = Path.Combine(_webHostEnvironment.WebRootPath, "Design");
                Directory.CreateDirectory(imageDirectory);
                foreach (var file in files.Files)
                {
                    FileInfo fi = new FileInfo(file.FileName);
                    string Design = Guid.NewGuid().ToString() + fi.Extension;
                    string path = Path.Combine(imageDirectory, Design);
                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }

                    if (count == 0)
                    {
                        model.Picture = Design;
                        count++;
                    }
                    else
                    {
                        model.Picture2 = Design;
                        count++;
                    }

                }
            }
            var design = await _designService.Create(model);
            if (design.Status == false)
            {
                return BadRequest(design);
            }
            return Ok(design);
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var design = await _designService.GetAll();
            if (design.Status == false)
            {
                return BadRequest(design);
            }
            return Ok(design);
        }
        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var design = await _designService.Get(id);
            if (design.Status == false)
            {
                return BadRequest(design);
            }
            return Ok(design);
        }
        [HttpGet("GetDesignByClothId/{id}")]
        public async Task<IActionResult> GetDesignByClothId([FromRoute] int id)
        {
            var design = await _designService.GetDesignByClothId(id);
            if (design.Status == false)
            {
                return BadRequest(design);
            }
            return Ok(design);
        }
    }
}
