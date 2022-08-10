using TailoringApp.Dto;

namespace TailoringApp.Interface.IService
{
    public interface IColourService
    {
        Task<BaseResponse<ColourDto>> Create(ColourRequestModel model);
        Task<BaseResponse<ColourDto>> Get(int id);
        Task<BaseResponse<IEnumerable<ColourDto>>> GetAll();
    }
}
