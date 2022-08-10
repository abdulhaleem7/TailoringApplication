using TailoringApp.Dto;

namespace TailoringApp.Interface.IService
{
    public interface IDesignService
    {
        Task<BaseResponse<DesignDto>> Create(DesignRequestModel model);
        Task<BaseResponse<DesignDto>> Get(int id);
        Task<BaseResponse<IEnumerable<DesignDto>>> GetAll();
        Task<BaseResponse<IEnumerable<DesignDto>>> GetDesignByClothId(int id);
    }
}
