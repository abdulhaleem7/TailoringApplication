using TailoringApp.Dto;
using TailoringApp.Identity;
using TailoringApp.Interface.IRepository;
using TailoringApp.Interface.IService;

namespace TailoringApp.Implementation.Services
{
    public class RoleService : IRoleService
    {

        private readonly IRoleRepository _roleRepository;

        public RoleService(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public async Task<BaseResponse<RoleDto>> Create(CreateRequestModel model)
        {
            var roleExist = await _roleRepository.GetAsync(a => a.Name == model.Name);
            if (roleExist != null) return new BaseResponse<RoleDto>
            {
                Message = "Role Already Exist",
                Status = false,
            };
            var role = new Role
            {
                Name = model.Name,
            };
            await _roleRepository.Create(role);
            return new BaseResponse<RoleDto>
            {
                Message = "Success",
                Status = true,
            };
        }

        public async Task<BaseResponse<RoleDto>> Get(int id)
        {
            var role = await _roleRepository.GetAsync(id);
            if (role == null) return new BaseResponse<RoleDto>
            {
                Message = "failed",
                Status = false
            };
            return new BaseResponse<RoleDto>
            {
                Message = "succesful",
                Status = true,
                Data = new RoleDto
                {
                    Id = role.Id,
                    Name = role.Name,
                    Users = role.UserRole.Select(x => new UserDto
                    {
                        Email = x.User.Email,
                    }).ToList(),
                }
            };
        }

        public async Task<BaseResponse<IEnumerable<RoleDto>>> GetAll()
        {
            var roles = await _roleRepository.GetAllAsync();
            var ListOfRoles = roles.ToList().Select(a => new RoleDto
            {
                Id = a.Id,
                Name = a.Name,
                Users = a.UserRole.Select(b => new UserDto
                {
                    Email = b.User.Email,
                }).ToList(),
            });
            return new BaseResponse<IEnumerable<RoleDto>>
            {
                Message = "Success",
                Status = true,
                Data = ListOfRoles,
            };

        }
    }
}

