using TailoringApp.Dto;

namespace TailoringApp.Interface.IService
{
    public interface ICategoryService
    {
        Task<BaseResponse<CategoryDto>> Create(CategoryRequestModel model);
        Task<BaseResponse<CategoryDto>> Get(int id);
        Task<BaseResponse<IEnumerable<CategoryDto>>> GetAll();
    }
}
