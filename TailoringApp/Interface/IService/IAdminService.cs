using TailoringApp.Dto;

namespace TailoringApp.Interface.IService
{
    public interface IAdminService
    {
        Task<BaseResponse<AdminDto>> Create(AdminRequestModel model);
        Task<BaseResponse<AdminDto>> Get(int id);
        Task<BaseResponse<IEnumerable<AdminDto>>> GetAll();
    }
}
