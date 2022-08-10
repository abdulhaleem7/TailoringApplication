using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TailoringApp.Dto;
using TailoringApp.Interface.IService;

namespace TailoringApp.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public CustomerController(ICustomerService customerService , IWebHostEnvironment webHostEnvironment)
        {
            _customerService = customerService;
            _webHostEnvironment = webHostEnvironment;
        }
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromForm] CustomerRequestModel model)
        {
            var customer = await _customerService.Create(model);
            if (customer.Status == false)
            {
                return BadRequest(customer);
            }
            return Ok(customer);
        }
        
        [HttpGet("Details/{id}")]
        public async Task<IActionResult> Details([FromRoute] int id)
        {
            var customer = await _customerService.Get(id);
            if (customer.Status == false)
            {
                return BadRequest(customer.Message);
            }
            return Ok(customer);
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var customer = await _customerService.GetAll();
            if (customer.Status == false)
            {
                return BadRequest(customer.Message);
            }
            return Ok(customer);
        }
    }
}
