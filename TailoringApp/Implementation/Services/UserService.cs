using TailoringApp.Dto;
using TailoringApp.Interface.IRepository;
using TailoringApp.Interface.IService;

namespace TailoringApp.Implementation.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;
        public UserService(IUserRepository userRepository, IRoleRepository roleRepository)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
        }

        
        public async Task<BaseResponse<UserDto>> Get(int id)
        {
            var user = await _userRepository.GetAsync(id);
            if (user == null) return new BaseResponse<UserDto>
            {
                Message = "User not found",
                Status = false,
            };
            return new BaseResponse<UserDto>
            {
                Message = "Success",
                Status = true,
                Data = new UserDto
                {
                    Id = user.Id,                   
                    Email = user.Email,
                    Roles = user.UserRoles.Select(a => new RoleDto
                    {
                        Id = a.Role.Id,
                        Name = a.Role.Name,
                    }).ToList(),
                }
            };
        }

        public async Task<BaseResponse<IEnumerable<UserDto>>> GetAll()
        {
            var users = await _userRepository.GetAllAsync();
            var listOfUsers = users.ToList().Select(user => new UserDto
            {
                Id = user.Id,
                Email = user.Email,
                Roles = user.UserRoles.Select(a => new RoleDto
                {
                    Id = a.Role.Id,
                    Name = a.Role.Name,
                }).ToList(),
            });

            return new BaseResponse<IEnumerable<UserDto>>
            {
                Message = "success",
                Status = true,
                Data = listOfUsers,
            };
        }

        public async Task<BaseResponse<UserDto>> Login(LoginRequestModel loginRequest)
        {
            var user = await _userRepository.GetAsync(a => a.Email == loginRequest.Email && a.Password == loginRequest.Password);
            if (user == null) return new BaseResponse<UserDto>
            {
                Message = "email or password incorrect",
                Status = false,
            };
            return new BaseResponse<UserDto>
            {
                Message = "login successful",
                Status = true,
                Data = new UserDto
                {
                    Id = user.Id,
                    Email = user.Email,
                    Password = user.Password,
                    Roles = user.UserRoles.Select(a => new RoleDto
                    {
                        Id = a.Role.Id,
                        Name = a.Role.Name,
                    }).ToList(),
                },
            };
        }
    }
}
