using TailoringApp.Dto;

namespace TailoringApp.Interface.IService
{
    public interface IRoleService
    {
        Task<BaseResponse<RoleDto>> Create(CreateRequestModel model);
        Task<BaseResponse<RoleDto>> Get(int id);
        Task<BaseResponse<IEnumerable<RoleDto>>> GetAll();
    }
}
