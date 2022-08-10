using TailoringApp.Dto;
using TailoringApp.Entity;
using TailoringApp.Interface.IRepository;
using TailoringApp.Interface.IService;

namespace TailoringApp.Implementation.Services
{
    public class MeasurementService : IMeasurementService
    {
        private readonly IMeasurementRepository _measurementRepository;
        public MeasurementService(IMeasurementRepository measurementRepository)
        {
            _measurementRepository = measurementRepository;
        }
        public async Task<BaseResponse<MeasurementDto>> Create(MeasurementRequestModel model)
        {
            var getMeasurement = await _measurementRepository.GetAsync(a => a.Name == model.Name);
            var measuremnet = new Measurement
            {
                Name = model.Name,
                Picture = model.Picture,
                ClothId = model.ClothId,
            };
            await _measurementRepository.Create(measuremnet);
            return new BaseResponse<MeasurementDto>
            {
                Data = new MeasurementDto
                {
                    Id = measuremnet.Id,
                    Name = measuremnet.Name,
                    Picture = measuremnet.Picture,
                },
                Status = true,
                Message = "done"

            };
        }


        public async Task<BaseResponse<MeasurementDto>> Get(int id)
        {
            var getMeasurement = await _measurementRepository.GetAsync(id);
            if(getMeasurement == null)
            {
                return new BaseResponse<MeasurementDto>
                {
                    Message = "failed",
                    Status = false,
                };
            }
            return new BaseResponse<MeasurementDto>
            {
                Data = new MeasurementDto
                {
                    Id = getMeasurement.Id,
                    Name = getMeasurement.Name,
                    Picture = getMeasurement.Picture,
                },
                Message = "success",
                Status = true
            };
        }

        public async Task<BaseResponse<IEnumerable<MeasurementDto>>> GetAll()
        {
            var getAll = await _measurementRepository.GetAllAsync();
            if (GetAll == null) return new BaseResponse<IEnumerable<MeasurementDto>>
            {
                Message = "failed",
                Status = false,
            };
            var getAllMeasurement = getAll.ToList().Select(a => new MeasurementDto
            {
                Id = a.Id,
                Name = a.Name,
                Picture = a.Picture,
            });
            return new BaseResponse<IEnumerable<MeasurementDto>>
            {
                Data = getAllMeasurement,
                Status = true,
                Message = "success"
            };
        }

        public async Task<BaseResponse<IEnumerable<MeasurementDto>>> GetMeasurementByClothId(int id)
        {
            var getMeasurement = await _measurementRepository.GetSelectedAsync(a => a.Cloth.Id == id);
            if (getMeasurement == null) return new BaseResponse<IEnumerable<MeasurementDto>> { Message ="failed",Status = false};
            var getListOfMeasurement = getMeasurement.ToList().Select(a => new MeasurementDto
            {
                Name = a.Name,
                Picture = a.Picture,
            });
            return new BaseResponse<IEnumerable<MeasurementDto>> { Data = getListOfMeasurement,Status=true,Message = "success"};
        }
    }
}
