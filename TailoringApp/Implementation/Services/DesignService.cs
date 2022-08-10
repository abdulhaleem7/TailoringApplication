using TailoringApp.Dto;
using TailoringApp.Entity;
using TailoringApp.Interface.IRepository;
using TailoringApp.Interface.IService;

namespace TailoringApp.Implementation.Services
{
    public class DesignService : IDesignService
    {
        private readonly IDesignRepository _designRepository;
        private readonly IClothRepository _clothRepository;
        public DesignService(IDesignRepository designRepository, IClothRepository clothRepository)
        {
            _designRepository = designRepository;
            _clothRepository = clothRepository;
        }
        public async Task<BaseResponse<DesignDto>> Create(DesignRequestModel model)
        {
            var get = await _designRepository.GetAsync(x => x.Name == model.Name);
            if (get != null) return new BaseResponse<DesignDto> { Status = false, Message = "Name already exist" };
            var design = new Design
            {
                Name = model.Name,
                Picture = model.Picture,
                Picture2 = model.Picture2,
                ClothId = model.ClothId,
            };
            await _designRepository.Create(design);
            var getCloth = await _clothRepository.GetAsync(design.ClothId); 
            return new BaseResponse<DesignDto>
            {
                Data = new DesignDto
                {
                    Id = design.Id,
                    Name = design.Name,
                    Picture = design.Picture,
                    Picture2 = design.Picture2,
                    ClothName = getCloth.Name,
                }
                ,
                Status = true,
                Message = "Success"
            };
        }

        public async Task<BaseResponse<DesignDto>> Get(int id)
        {
            var getDesign = await _designRepository.GetAsync(id);
            if(getDesign == null)return new BaseResponse<DesignDto> { Message="failed",Status=false};
            return new BaseResponse<DesignDto>
            {
                Data = new DesignDto
                {
                    Id = getDesign.Id,
                    Name = getDesign.Name,
                    Picture = getDesign.Picture,
                    Picture2 = getDesign.Picture2,
                },
                Status = true,
                Message = "success",
            };
        }

        public async Task<BaseResponse<IEnumerable<DesignDto>>> GetAll()
        {
            var all = await _designRepository.GetAllAsync();
            if(all == null)return new BaseResponse<IEnumerable<DesignDto>> { Message="failed",Status = false};
            var getAllDesign = all.ToList().Select(a => new DesignDto
            {
                Id = a.Id,
                Name = a.Name,
                Picture = a.Picture,
                Picture2 = a.Picture2,
            });
            return new BaseResponse<IEnumerable<DesignDto>>
            {
                Data = getAllDesign,
                Status = true,
                Message = "success"
            };
        }

        public async Task<BaseResponse<IEnumerable<DesignDto>>> GetDesignByClothId(int id)
        {
            var getDesign = await _designRepository.GetSelectedAsync(x => x.Cloth.Id == id);
            if (getDesign == null) return new BaseResponse<IEnumerable<DesignDto>> { Message = "failed", Status = false };
            var getListOfDesign = getDesign.ToList().Select(a => new DesignDto
            {
                Id = a.Id,
                Name = a.Name,
                Picture = a.Picture,
                Picture2 = a.Picture2,
            });
            return new BaseResponse<IEnumerable<DesignDto>>
            {
                Data = getListOfDesign,
                Message = "success",
                Status = true,
            };
        }
    }
}
