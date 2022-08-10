using TailoringApp.Dto;

namespace TailoringApp.Interface.IService
{
    public interface IClothService
    {
        Task<BaseResponse<ClothDto>> Create(ClothRequestModel model);
        Task<BaseResponse<ClothDto>> Get(int id);
        Task<BaseResponse<IEnumerable<ClothDto>>> GetAll();
        Task<BaseResponse<IEnumerable<ClothDto>>> GetClothByCategoryId(int Id);
    }
}
