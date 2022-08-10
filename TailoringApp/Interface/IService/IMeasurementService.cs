using TailoringApp.Dto;

namespace TailoringApp.Interface.IService
{
    public interface IMeasurementService
    {
        Task<BaseResponse<MeasurementDto>> Create(MeasurementRequestModel model);
        Task<BaseResponse<MeasurementDto>> Get(int id);
        Task<BaseResponse<IEnumerable<MeasurementDto>>> GetAll();
        Task<BaseResponse<IEnumerable<MeasurementDto>>> GetMeasurementByClothId(int id);
       
    }
}
