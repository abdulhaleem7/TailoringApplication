using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TailoringApp.Dto;
using TailoringApp.Interface.IService;

namespace TailoringApp.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public AdminController(IAdminService adminService , IWebHostEnvironment webHostEnvironment)
        {
            _adminService = adminService;
            _webHostEnvironment = webHostEnvironment;
        }
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromForm] AdminRequestModel model)
        {
            var admin = await _adminService.Create(model);
            if(admin.Status == false)
            {
                return BadRequest(admin.Message);
            }
            return Ok(admin);
        }

        
        [HttpGet("Details/{id}")]
        public async Task<IActionResult> Details([FromRoute] int id)
        {
            var admin = await _adminService.Get(id);
            if(admin.Status == false)
            {
                return BadRequest(admin.Message);
            }
            return Ok(admin);
        }
       
        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            var admin = await _adminService.GetAll();
            if (admin.Status == false)
            {
                return BadRequest(admin.Message);
            }
            return Ok(admin);
        }
    }
}
