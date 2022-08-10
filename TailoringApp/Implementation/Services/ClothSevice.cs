using System.Linq;
using TailoringApp.Dto;
using TailoringApp.Entity;
using TailoringApp.Interface.IRepository;
using TailoringApp.Interface.IService;

namespace TailoringApp.Implementation.Services
{
    public class ClothSevice : IClothService
    {
        private readonly IClothRepository _clothRepository;
        public ClothSevice(IClothRepository clothRepository)
        {
            _clothRepository = clothRepository;
        }
        public async Task<BaseResponse<ClothDto>> Create(ClothRequestModel model)
        {
            var getName = await _clothRepository.GetAsync(x => x.Name == model.Name);
            if(getName!= null)
            {
                return new BaseResponse<ClothDto> { Message = "Name Already Exist", Status = false };
            }
            var cloth = new Cloth
            {
                CategoryId = model.CategoryId,
                Picture = model.Picture,
                Price = model.Price,
                Name = model.Name,
            };
            await _clothRepository.Create(cloth);
            return new BaseResponse<ClothDto>
            {
                Data = new ClothDto
                {
                    Id = cloth.Id,
                    Picture = cloth.Picture,
                    Price = cloth.Price,
                   Name = cloth.Name,
                },
                Message = "success",
                Status = true,
            };

        }

        public async Task<BaseResponse<ClothDto>> Get(int id)
        {
            var get = await _clothRepository.GetAsync(id);
            if(get == null)
            {
                return new BaseResponse<ClothDto>
                {
                    Message = "failed",
                    Status = false,
                };
            }
            return new BaseResponse<ClothDto>
            {
                Data = new ClothDto
                {
                    Id = get.Id,
                    Picture = get.Picture,
                    Price = get.Price,
                    Name = get.Name,
                },
                Status = true,
                Message = "success"
            };
        }

        public async Task<BaseResponse<IEnumerable<ClothDto>>> GetAll()
        {
            var getAll = await _clothRepository.GetAllAsync();
            if(getAll == null)
            {
                return new BaseResponse<IEnumerable<ClothDto>>
                {
                    Message = "failed",
                    Status = false,
                };
            }
            var listOfCloth = getAll.ToList().Select(a => new ClothDto
            {
                Id = a.Id,
                Picture = a.Picture,
                Price = a.Price,
                Name = a.Name,

            });
            return new BaseResponse<IEnumerable<ClothDto>>
            {
                Data = listOfCloth,
                Message = "success",
                Status = true,

            };
        }

        public async Task<BaseResponse<IEnumerable<ClothDto>>> GetClothByCategoryId(int id)
        {
            var getClothByCategoryId = await _clothRepository.GetSelectedAsync(x => x.Category.Id == id);
            if (getClothByCategoryId == null)return new BaseResponse<IEnumerable<ClothDto>>
            {
                Message = "failed",
                Status = false,
            };
            var getall = getClothByCategoryId.ToList().Select(x => new ClothDto
            {
                Id = x.Id,
                Picture = x.Picture,
                Price = x.Price,
                Name = x.Name,
                CategoryId = x.CategoryId,
            });
            return new BaseResponse<IEnumerable<ClothDto>>
            {
                Data = getall,
                Message = "success",
                Status = true,
            };
            /*return new BaseResponse<ClothDto>
            {
                Data = new ClothDto
                {
                    Id = getClothByCategoryId.Id,
                    Price = getClothByCategoryId.Price,
                    Picture = getClothByCategoryId.Picture,
                    Name = getClothByCategoryId.Name,
                },
                Message = "success",
                Status = true,

            };*/
        }
    }
}
