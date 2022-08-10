using Microsoft.AspNetCore.Mvc;
using TailoringApp.Auth;
using TailoringApp.Dto;
using TailoringApp.Interface.IService;

namespace TailoringApp.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IJwtAuthentication _jwtAuthentication;
        private readonly IUserService _userService;
        public UserController(IJwtAuthentication jwtAuthentication, IUserService userService)
        {
            _jwtAuthentication = jwtAuthentication;
            _userService = userService;
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginRequestModel createUser)
        {
            var create = await _userService.Login(createUser);
            if (create.Status == false)
            {
                var logins = new BaseResponse<UserDto>
                {
                    Message = "incorrect password or email",
                    Status = false,
                    Data = create.Data,
                };
                return BadRequest(logins);
            }
            var token = _jwtAuthentication.GenerateToken(create.Data);
            var user = new LoginBaseResponse
            {
                IsSucess = true,
                Message = "User has logged in sucessfully",
                Data = create.Data,
                Token = token
            };
            return Ok(user);

        }
    
        [HttpGet("Details/{id}")]
        public async Task<IActionResult> Details([FromRoute] int id)
        {
            var get = await _userService.Get(id);
            if(get.Status == false)
            {
                return BadRequest(get.Message);
            }
            return Ok(get);
        }
        [HttpGet("GetAllUsers")]
        public async Task<IActionResult> GetAllUsers()
        {
            var getAll = await _userService.GetAll();
            if (getAll.Status == false)
            {
                return BadRequest(getAll.Message);
            }
            return Ok(getAll);
        }
    }
}
