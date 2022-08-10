using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TailoringApp.Dto;
using TailoringApp.Interface.IService;

namespace TailoringApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColourController : ControllerBase
    {
        private readonly IColourService _colourService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ColourController(IColourService colourService, IWebHostEnvironment webHostEnvironment)
        {
            _colourService = colourService;
            _webHostEnvironment = webHostEnvironment;
        }
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromForm] ColourRequestModel model)
        {
            int count = 0;
            var files = HttpContext.Request.Form;
            if (files != null && files.Count > 0)
            {
                string imageDirectory = Path.Combine(_webHostEnvironment.WebRootPath, "Colour");
                Directory.CreateDirectory(imageDirectory);
                foreach (var file in files.Files)
                {
                    FileInfo fi = new FileInfo(file.FileName);
                    string Colour = Guid.NewGuid().ToString() + fi.Extension;
                    string path = Path.Combine(imageDirectory, Colour);
                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }

                    if (count == 0)
                    {
                        model.Image = Colour;
                        count++;
                    }

                }
            }
            var colours = await _colourService.Create(model);
            if (colours.Status == false)
            {
                return BadRequest(colours);
            }
            return Ok(colours);
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var colours = await _colourService.GetAll();
            if (colours.Status == false)
            {
                return BadRequest(colours.Message);
            }
            return Ok(colours);
        }
        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var colours = await _colourService.Get(id);
            if (colours.Status == false)
            {
                return BadRequest(colours.Message);
            }
            return Ok(colours);
        }
    }
}
