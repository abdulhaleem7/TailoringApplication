using TailoringApp.Dto;
using TailoringApp.Entity;
using TailoringApp.Interface.IRepository;
using TailoringApp.Interface.IService;

namespace TailoringApp.Implementation.Services
{
    public class CategoryService : ICategoryService
    {

        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task<BaseResponse<CategoryDto>> Create(CategoryRequestModel model)
        {
            var getCategory = await _categoryRepository.GetAsync(x => x.Name == model.Name);
            if (getCategory != null) return new BaseResponse<CategoryDto>
            {
                Message = "failed",
                Status = false,
            };
            var category = new Category
            {
                Name = model.Name,
                Description = model.Description,
            };
            await _categoryRepository.Create(category);
            return new BaseResponse<CategoryDto>
            {
                Message = "done",
                Status = true,
                Data = new CategoryDto
                {
                    Id = category.Id,
                    Name = category.Name,
                    Description = category.Description,
                }
            };
        }

        public async Task<BaseResponse<CategoryDto>> Get(int id)
        {
            var getCategory = await _categoryRepository.GetAsync(id);
            if (getCategory == null) return new BaseResponse<CategoryDto>
            {
                Message = "failed",
                Status = false,
            };
            return new BaseResponse<CategoryDto>
            {
                Data = new CategoryDto
                {
                    Id = getCategory.Id,
                    Name = getCategory.Name,
                    Description = getCategory.Description,
                }
            };
        }

        public async Task<BaseResponse<IEnumerable<CategoryDto>>> GetAll()
        {
            var getAllCategory = await _categoryRepository.GetAllAsync();
            if (getAllCategory == null) return new BaseResponse<IEnumerable<CategoryDto>>
            {
                Message = "failed",
                Status = false,
            };
            var listOfCategory = getAllCategory.ToList().Select(category => new CategoryDto
            {
                Id = category.Id,
                Name = category.Name,
                Description = category.Description
            });
            return new BaseResponse<IEnumerable<CategoryDto>>
            {
                Data = listOfCategory,
                Message = "success",
                Status = true,
            };
        }
    }
}
