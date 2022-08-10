using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TailoringApp.Dto;
using TailoringApp.Interface.IService;

namespace TailoringApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeasurementController : ControllerBase
    {
        private readonly IMeasurementService _measurementService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public MeasurementController(IMeasurementService measurementService, IWebHostEnvironment webHostEnvironment)
        {
             _measurementService= measurementService;
            _webHostEnvironment = webHostEnvironment;
        }
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromForm]MeasurementRequestModel model)
        {
            int count = 0;
            var files = HttpContext.Request.Form;
            if (files != null && files.Count > 0)
            {
                string imageDirectory = Path.Combine(_webHostEnvironment.WebRootPath, "measurement");
                Directory.CreateDirectory(imageDirectory);
                foreach (var file in files.Files)
                {
                    FileInfo fi = new FileInfo(file.FileName);
                    string measurement = Guid.NewGuid().ToString() + fi.Extension;
                    string path = Path.Combine(imageDirectory, measurement);
                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }

                    if (count == 0)
                    {
                        model.Picture = measurement;
                        count++;
                    }

                }
            }
            var measurements = await _measurementService.Create(model);
            if (measurements.Status == false)
            {
                return BadRequest(measurements.Message);
            }
            return Ok(measurements);
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var measurements = await _measurementService.GetAll();
            if (measurements.Status == false)
            {
                return BadRequest(measurements.Message);
            }
            return Ok(measurements);
        }
        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var measurements = await _measurementService.Get(id);
            if (measurements.Status == false)
            {
                return BadRequest(measurements.Message);
            }
            return Ok(measurements);
        }
        [HttpGet("GetMeasurementByClothId/{id}")]
        public async Task<IActionResult> GetMeasurementByClothId([FromRoute] int id)
        {
            var measurements = await _measurementService.GetMeasurementByClothId(id);
            if (measurements.Status == false)
            {
                return BadRequest(measurements.Message);
            }
            return Ok(measurements);
        }
    }
}
