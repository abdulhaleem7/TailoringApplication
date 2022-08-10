using Microsoft.AspNetCore.Mvc;
using TailoringApp.Dto;
using TailoringApp.Interface.IService;

namespace TailoringApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;
        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody]CreateRequestModel model)
        {
            var role = await _roleService.Create(model);
            if(role.Status == false)
            {
                return BadRequest(role.Message);
            }
            return Ok(role);
        }
        [HttpGet("Detail/{id}")]
        public async Task<IActionResult> Details([FromRoute] int id)
        {
            var role = await _roleService.Get(id);
            if (role.Status == false)
            {
                return BadRequest(role.Message);
            }
            return Ok(role);
        }
        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            var role = await _roleService.GetAll();
            if (role.Status == false)
            {
                return BadRequest(role.Message);
            }
            return Ok(role);
        }
    }

}
