using TailoringApp.Dto;
using TailoringApp.Entity;
using TailoringApp.Interface.IRepository;
using TailoringApp.Interface.IService;

namespace TailoringApp.Implementation.Services
{
    public class ColourService : IColourService
    {
        private readonly IColourRepository _colourRepository;
        public ColourService(IColourRepository colourRepository)
        {
            _colourRepository = colourRepository;
        }
        public async Task<BaseResponse<ColourDto>> Create(ColourRequestModel model)
        {
            var get = await _colourRepository.GetAsync(x=>x.Name == model.Name);
            if(get != null)
            {
                return new BaseResponse<ColourDto>
                {
                    Message ="failed",
                    Status = false,
                };
            }
            var colour = new Colour
            {
                Name = model.Name,
                Image = model.Image,
            };
            await _colourRepository.Create(colour);
            return new BaseResponse<ColourDto>
            {
                Message = "success",
                Status = true,
                Data = new ColourDto
                {
                    Id = colour.Id,
                    Image = model.Image,
                    Name = model.Name,
                }
            };
        }

        public async Task<BaseResponse<ColourDto>> Get(int id)
        {
            var get = await _colourRepository.GetAsync(id);
            if(get == null)
            {
                return new BaseResponse<ColourDto>
                {
                    Message = "failed",
                    Status = false,
                };
            }
            return new BaseResponse<ColourDto>
            {
                Data = new ColourDto
                {
                    Id = get.Id,
                    Name = get.Name,
                    Image = get.Image,
                },
                Message = "success",
                Status = true,
            };
        }

        public async Task<BaseResponse<IEnumerable<ColourDto>>> GetAll()
        {
            var getAllColour = await _colourRepository.GetAllAsync();
            if(getAllColour == null)
            {
                return new BaseResponse<IEnumerable<ColourDto>>
                {
                    Message = "failed",
                    Status = false,
                };
            }
            var getAllColourList = getAllColour.ToList().Select(a => new ColourDto
            {
                Id = a.Id,
                Name = a.Name,
                Image = a.Image,
            });
           return new BaseResponse<IEnumerable<ColourDto>>
           {
               Data = getAllColourList,
               Status = true,
               Message = "success"
           };
        }
    }
}
